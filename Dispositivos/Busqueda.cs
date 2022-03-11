using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Dispositivos
{
    public partial class Busqueda : Form
    {
        NpgsqlConnection cn;
        public Busqueda()
        {
            InitializeComponent();
        }

        private void Busqueda_Load(object sender, EventArgs e)
        {
            //Conectar a una base de datos
            string str = "Server=127.0.0.1;Port=5432;Database=Hoja_de_vida;User Id=postgres;Password=11555;";
            cn = new NpgsqlConnection();
            cn.ConnectionString = str;
            cn.Open();

            //Cargar los datos de la grilla final
            grilla_1.ColumnCount = 8;
            grilla_1.Columns[0].HeaderText = "Fecha de Emisión";
            grilla_1.Columns[1].HeaderText = "Responsable Registro";
            grilla_1.Columns[2].HeaderText = "Nombre Equipo";
            grilla_1.Columns[3].HeaderText = "Serie";
            grilla_1.Columns[4].HeaderText = "Modelo";
            grilla_1.Columns[5].HeaderText = "Año de Fabricación";
            grilla_1.Columns[6].HeaderText = "Estatus";
            grilla_1.Columns[7].HeaderText = "Servicio";

            //Llamar datos desde la grilla
            grilla_1.Rows.Clear();
            NpgsqlCommand cme = new NpgsqlCommand();
            cme.CommandText = " SELECT R.fecha AS fecha_emision, R.nombre_resp AS Responsable_registro, E.nombre, E.serie, E.modelo, E.fab_year, B.estatus, U.servicio FROM registro_elab R INNER JOIN equip_description E ON R.n10_serie = E.serie INNER JOIN estado_bien B ON E.serie = B.n7_serie INNER JOIN ubicacion_equipo U ON U.n4_serie = E.serie GROUP BY R.fecha, E.nombre, E.serie, R.nombre_resp, E.modelo,E.fab_year, B.estatus, U.servicio ORDER BY R.fecha desc;";
            cme.Connection = cn;
            NpgsqlDataReader dm = cme.ExecuteReader();
            while (dm.Read())
            {
                grilla_1.Rows.Add(dm[0], dm[1], dm[2], dm[3], dm[4], dm[5], dm[6], dm[7]);
            }
            dm.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void grilla_2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void boton_busqueda_Click(object sender, EventArgs e)
        {
            //Cargar los datos de la descripcion bien
            desp_bien_busqueda.ColumnCount = 6;
            desp_bien_busqueda.Columns[0].HeaderText = "Bien";
            desp_bien_busqueda.Columns[1].HeaderText = "Nombre Registro";
            desp_bien_busqueda.Columns[2].HeaderText = "Marca";
            desp_bien_busqueda.Columns[3].HeaderText = "Modelo";
            desp_bien_busqueda.Columns[4].HeaderText = "Serie";
            desp_bien_busqueda.Columns[5].HeaderText = "Año de Fabricación";

            //Ejecucion en postgresql
            desp_bien_busqueda.Rows.Clear();
            NpgsqlCommand sma = new NpgsqlCommand();
            sma.CommandText = " SELECT * FROM equip_description WHERE serie = '" + serie_busqueda.Text + "';";
            sma.Connection = cn;
            NpgsqlDataReader da = sma.ExecuteReader();
            while (da.Read())
            {
                desp_bien_busqueda.Rows.Add(da[0], da[1], da[2], da[3], da[4], da[5]);
            }
            da.Close();

            //PARTE 2: Cargar los datos de la datos tecnicos
            grilla_2.ColumnCount = 11;
            grilla_2.Columns[0].HeaderText = "Numero de Serie";
            grilla_2.Columns[1].HeaderText = "Voltaje";
            grilla_2.Columns[2].HeaderText = "Fase Voltaje";
            grilla_2.Columns[3].HeaderText = "Corriente";
            grilla_2.Columns[4].HeaderText = "Potencia";
            grilla_2.Columns[5].HeaderText = "Frecuencia";
            grilla_2.Columns[6].HeaderText = "Batería";
            grilla_2.Columns[7].HeaderText = "Canales";
            grilla_2.Columns[8].HeaderText = "Memoria";
            grilla_2.Columns[9].HeaderText = "Impresión";
            grilla_2.Columns[10].HeaderText = "Comentarios";

            //Ejecucion en postgresql
            grilla_2.Rows.Clear();
            NpgsqlCommand smb = new NpgsqlCommand();
            smb.CommandText = " SELECT * FROM equip_tdata WHERE n_serie = '" + serie_busqueda.Text + "';";
            smb.Connection = cn;
            NpgsqlDataReader db = smb.ExecuteReader();
            while (db.Read())
            {
                grilla_2.Rows.Add(db[0], db[1], db[2], db[3], db[4], db[5], db[6], db[7], db[8], db[9], db[10]);
            }
            db.Close();


            //PARTE 3: Cargar los datos de la DATOS ECONOMICOS
            
            grilla_3.ColumnCount = 6;
            grilla_3.Columns[0].HeaderText = "Numero de Serie";
            grilla_3.Columns[1].HeaderText = "Valor de Adquisición";
            grilla_3.Columns[2].HeaderText = "Numero de Factura";
            grilla_3.Columns[3].HeaderText = "Forma de Adquisición";
            grilla_3.Columns[4].HeaderText = "Fecha Adquisición";
            grilla_3.Columns[5].HeaderText = "Vida útil";

            //Ejecucion en postgresql
            grilla_3.Rows.Clear();
            NpgsqlCommand smc = new NpgsqlCommand();
            smc.CommandText = " SELECT * FROM datos_economicos WHERE n3_serie = '" + serie_busqueda.Text + "';";
            smc.Connection = cn;
            NpgsqlDataReader dc = smc.ExecuteReader();
            while (dc.Read())
            {
                grilla_3.Rows.Add(dc[0], dc[1], dc[2], dc[3], dc[4], dc[5]);
            }
            dc.Close();

            //PARTE 4: Cargar los datos de la UBICACIÓN DEL EQUIPO

            grilla_4.ColumnCount = 9;
            grilla_4.Columns[0].HeaderText = "Numero de Serie";
            grilla_4.Columns[1].HeaderText = "Unidad Operativa";
            grilla_4.Columns[2].HeaderText = "Servicio";
            grilla_4.Columns[3].HeaderText = "Sub-Servicio";
            grilla_4.Columns[4].HeaderText = "Nombre Custodio";
            grilla_4.Columns[5].HeaderText = "Zona";
            grilla_4.Columns[6].HeaderText = "Distrito";
            grilla_4.Columns[7].HeaderText = "Provincia";
            grilla_4.Columns[8].HeaderText = "Ciudad";

            //Ejecucion en postgresql
            grilla_4.Rows.Clear();
            NpgsqlCommand smd = new NpgsqlCommand();
            smd.CommandText = " SELECT * FROM ubicacion_equipo WHERE n4_serie = '" + serie_busqueda.Text + "';";
            smd.Connection = cn;
            NpgsqlDataReader dd = smd.ExecuteReader();
            while (dd.Read())
            {
                grilla_4.Rows.Add(dd[0], dd[1], dd[2], dd[3], dd[4], dd[5], dd[6], dd[7], dd[8]);
            }
            dd.Close();

            //PARTE 4: Cargar los datos de la DATOS DE PROOVEDOR

            grilla_5.ColumnCount = 25;
            grilla_5.Columns[0].HeaderText = "Numero de Serie";
            grilla_5.Columns[1].HeaderText = "Fabricante";
            grilla_5.Columns[2].HeaderText = "Dirección Fabricante";
            grilla_5.Columns[3].HeaderText = "Teléfono Fabricante";
            grilla_5.Columns[4].HeaderText = "Email Fabricante";

            grilla_5.Columns[5].HeaderText = "Proveedor";
            grilla_5.Columns[6].HeaderText = "Dirección Proveedor";
            grilla_5.Columns[7].HeaderText = "Teléfono Proveedor";
            grilla_5.Columns[8].HeaderText = "Email Proveedor";
            grilla_5.Columns[9].HeaderText = "Nombre Proveedor";

            grilla_5.Columns[10].HeaderText = "Representante en el País";
            grilla_5.Columns[11].HeaderText = "Dirección Representante";
            grilla_5.Columns[12].HeaderText = "Teléfono Representante";
            grilla_5.Columns[13].HeaderText = "Email Representante";
            grilla_5.Columns[14].HeaderText = "Nombre Representante";


            grilla_5.Columns[15].HeaderText = "Proveedor Mantenimiento";
            grilla_5.Columns[16].HeaderText = "Dirección Mantenimiento";
            grilla_5.Columns[17].HeaderText = "Teléfono Mantenimiento";
            grilla_5.Columns[18].HeaderText = "Email Mantenimiento";
            grilla_5.Columns[19].HeaderText = "Nombre Mantenimiento";

            grilla_5.Columns[20].HeaderText = "Proveedor Calibración";
            grilla_5.Columns[21].HeaderText = "Dirección Calibración";
            grilla_5.Columns[22].HeaderText = "Teléfono Calibración";
            grilla_5.Columns[23].HeaderText = "Email Calibración";
            grilla_5.Columns[24].HeaderText = "Nombre Calibración";

            //Ejecucion en postgresql
            grilla_5.Rows.Clear();
            NpgsqlCommand sme = new NpgsqlCommand();
            sme.CommandText = " SELECT * FROM datos_proveedor WHERE n5_serie = '" + serie_busqueda.Text + "';";
            sme.Connection = cn;
            NpgsqlDataReader de = sme.ExecuteReader();
            while (de.Read())
            {
                grilla_5.Rows.Add(de[0], de[1], de[2], de[3], de[4], de[5], de[6], de[7], de[8], de[9], de[10], de[11], de[12], de[13], de[14], de[15], de[16], de[17], de[18], de[19], de[20], de[21], de[22], de[23], de[24]);
            }
            de.Close();

            //PARTE 5: Cargar los datos de la REQUERIMENTOS DE FUNCIONAMIENTO

            grilla_6.ColumnCount = 29;
            grilla_6.Columns[0].HeaderText = "Numero de Serie";
            grilla_6.Columns[1].HeaderText = "Eléctrico";
            grilla_6.Columns[2].HeaderText = "Medición: Eléctrico";
            grilla_6.Columns[3].HeaderText = "Mecánico";
            grilla_6.Columns[4].HeaderText = "Medición: Mecánico";
            grilla_6.Columns[5].HeaderText = "Electrónico";
            grilla_6.Columns[6].HeaderText = "Medición: Electrónico";
            grilla_6.Columns[7].HeaderText = "Hidraúlico";
            grilla_6.Columns[8].HeaderText = "Medición: Hidraúlico";
            grilla_6.Columns[9].HeaderText = "Neumático";
            grilla_6.Columns[10].HeaderText = "Medición: Neumático";
            grilla_6.Columns[11].HeaderText = "Electromecánico";
            grilla_6.Columns[12].HeaderText = "Medición: Electromecánico";
            grilla_6.Columns[13].HeaderText = "Vapor";
            grilla_6.Columns[14].HeaderText = "Medición: Vapor";
            grilla_6.Columns[15].HeaderText = "GLP";
            grilla_6.Columns[16].HeaderText = "Medición: GLP";
            grilla_6.Columns[17].HeaderText = "Gases Medicinales";
            grilla_6.Columns[18].HeaderText = "Medición: Gases Medicinales";
            grilla_6.Columns[19].HeaderText = "Aire Comprimido";
            grilla_6.Columns[20].HeaderText = "Medición: Aire Comprimido";
            grilla_6.Columns[21].HeaderText = "Agua Fría";
            grilla_6.Columns[22].HeaderText = "Medición: Agua Fría";
            grilla_6.Columns[23].HeaderText = "Agua Caliente";
            grilla_6.Columns[24].HeaderText = "Medición: Agua Caliente";
            grilla_6.Columns[25].HeaderText = "Agua Descalcificada";
            grilla_6.Columns[26].HeaderText = "Medición: Agua Descalcificada";
            grilla_6.Columns[27].HeaderText = "Otro";
            grilla_6.Columns[28].HeaderText = "Estatus: Otro";

            //Ejecucion en postgresql
            grilla_6.Rows.Clear();
            NpgsqlCommand smf = new NpgsqlCommand();
            smf.CommandText = " SELECT * FROM equip_requirements WHERE n1_serie = '" + serie_busqueda.Text + "';";
            smf.Connection = cn;
            NpgsqlDataReader df = smf.ExecuteReader();
            while (df.Read())
            {
                grilla_6.Rows.Add(df[0], df[1], df[2], df[3], df[4], df[5], df[6], df[7], df[8], df[9], df[10], df[11], df[12], df[13], df[14], df[15], df[16], df[17], df[18], df[19], df[20], df[21], df[22], df[23], df[24], df[25], df[26], df[27], df[28]);
            }
            df.Close();

            //PARTE 6: Cargar los datos de la PARAMETROS MEDIDOS/TRANSMITIDOS

            grilla_7.ColumnCount = 27;
            grilla_7.Columns[0].HeaderText = "Numero de Serie";
            grilla_7.Columns[1].HeaderText = "ECG";
            grilla_7.Columns[2].HeaderText = "SPO2";
            grilla_7.Columns[3].HeaderText = "F.CARDIACA";
            grilla_7.Columns[4].HeaderText = "EEG";
            grilla_7.Columns[5].HeaderText = "SPCO";
            grilla_7.Columns[6].HeaderText = "CO";
            grilla_7.Columns[7].HeaderText = "02";
            grilla_7.Columns[8].HeaderText = "APNEA";
            grilla_7.Columns[9].HeaderText = "TEMPERATURA";
            grilla_7.Columns[10].HeaderText = "F.CEREBRAL";
            grilla_7.Columns[11].HeaderText = "F.RESPIRATORIA";
            grilla_7.Columns[12].HeaderText = "PRESION INVASIVA";
            grilla_7.Columns[13].HeaderText = "ARRITMIA";
            grilla_7.Columns[14].HeaderText = "PRESION NO INVASIVA";
            grilla_7.Columns[15].HeaderText = "PH";
            grilla_7.Columns[16].HeaderText = "MASA";
            grilla_7.Columns[17].HeaderText = "PIC ";
            grilla_7.Columns[18].HeaderText = "VCV ";
            grilla_7.Columns[19].HeaderText = "PVC";
            grilla_7.Columns[20].HeaderText = "SIMV";
            grilla_7.Columns[21].HeaderText = "PEEP";
            grilla_7.Columns[22].HeaderText = "PSV";
            grilla_7.Columns[23].HeaderText = "MAC";
            grilla_7.Columns[24].HeaderText = "NO2";
            grilla_7.Columns[25].HeaderText = "FIO2";
            grilla_7.Columns[26].HeaderText = "Otro";

            //Ejecucion en postgresql
            grilla_7.Rows.Clear();
            NpgsqlCommand smg = new NpgsqlCommand();
            smg.CommandText = " SELECT * FROM equip_parameters WHERE n2_serie = '" + serie_busqueda.Text + "';";
            smg.Connection = cn;
            NpgsqlDataReader dg = smg.ExecuteReader();
            while (dg.Read())
            {
                grilla_7.Rows.Add(dg[0], dg[1], dg[2], dg[3], dg[4], dg[5], dg[6], dg[7], dg[8], dg[9], dg[10], dg[11], dg[12], dg[13], dg[14], dg[15], dg[16], dg[17], dg[18], dg[19], dg[20], dg[21], dg[22], dg[23], dg[24], dg[25], dg[26]);
            }
            dg.Close();

            //PARTE 6: Cargar los datos de la INFORMACIÓN TÉCNICA
            
            grilla_8.ColumnCount = 7;
            grilla_8.Columns[0].HeaderText = "Número de Serie";
            grilla_8.Columns[1].HeaderText = "Manual de operación";
            grilla_8.Columns[2].HeaderText = "Manual de instalación";
            grilla_8.Columns[3].HeaderText = "Manual de servicio";
            grilla_8.Columns[4].HeaderText = "Manual de partes";
            grilla_8.Columns[5].HeaderText = "Otra literatura";
            grilla_8.Columns[6].HeaderText = "No existe información técnica";

            //Ejecucion en postgresql
            grilla_8.Rows.Clear();
            NpgsqlCommand smh = new NpgsqlCommand();
            smh.CommandText = " SELECT * FROM info_tecnica WHERE n6_serie = '" + serie_busqueda.Text + "';";
            smh.Connection = cn;
            NpgsqlDataReader dh = smh.ExecuteReader();
            while (dh.Read())
            {
                grilla_8.Rows.Add(dh[0], dh[1], dh[2], dh[3], dh[4], dh[5], dh[6]);
            }
            dh.Close();


            //PARTE 7: Cargar los datos de la ESTADO BIEN

            grilla_9.ColumnCount = 4;
            grilla_9.Columns[0].HeaderText = "Número de Serie";
            grilla_9.Columns[1].HeaderText = "Estatus";
            grilla_9.Columns[2].HeaderText = "No operativo: Estatus";
            grilla_9.Columns[3].HeaderText = "Observaciones";

            //Ejecucion en postgresql
            grilla_9.Rows.Clear();
            NpgsqlCommand smi = new NpgsqlCommand();
            smi.CommandText = " SELECT * FROM estado_bien WHERE n7_serie = '" + serie_busqueda.Text + "';";
            smi.Connection = cn;
            NpgsqlDataReader di = smi.ExecuteReader();
            while (di.Read())
            {
                grilla_9.Rows.Add(di[0], di[1], di[2], di[3]);
            }
            di.Close();

            //PARTE 8: ACCESORIOS DEL EQUIPO

            grilla_10.ColumnCount = 14;
            grilla_10.Columns[0].HeaderText = "Número de Serie";
            grilla_10.Columns[1].HeaderText = "1er Accesorio";
            grilla_10.Columns[2].HeaderText = "2do Accesorio";
            grilla_10.Columns[3].HeaderText = "3er Accesorio";
            grilla_10.Columns[4].HeaderText = "4to Accesorio";
            grilla_10.Columns[5].HeaderText = "5to Accesorio";
            grilla_10.Columns[6].HeaderText = "6to Accesorio";
            grilla_10.Columns[7].HeaderText = "Estado 1er Accesorio";
            grilla_10.Columns[8].HeaderText = "Estado 2do Accesorio";
            grilla_10.Columns[9].HeaderText = "Estado 3er Accesorio";
            grilla_10.Columns[10].HeaderText = "Estado 4to Accesorio";
            grilla_10.Columns[11].HeaderText = "Estado 5to Accesorio";
            grilla_10.Columns[12].HeaderText = "Estado 6to Accesorio";
            grilla_10.Columns[13].HeaderText = "Observaciones";

            //Ejecucion en postgresql
            grilla_10.Rows.Clear();
            NpgsqlCommand smj = new NpgsqlCommand();
            smj.CommandText = " SELECT * FROM accesorio_equipo WHERE n8_serie = '" + serie_busqueda.Text + "';";
            smj.Connection = cn;
            NpgsqlDataReader dj = smj.ExecuteReader();
            while (dj.Read())
            {
                grilla_10.Rows.Add(dj[0], dj[1], dj[2], dj[3], dj[4], dj[5], dj[6], dj[7], dj[8], dj[9], dj[10], dj[11], dj[12], dj[13]);
            }
            dj.Close();

            //PARTE 9: OTROS DATOS

            grilla_11.ColumnCount = 6;
            grilla_11.Columns[0].HeaderText = "Número de Serie";
            grilla_11.Columns[1].HeaderText = "Garantía";
            grilla_11.Columns[2].HeaderText = "Contrato";
            grilla_11.Columns[3].HeaderText = "Frecuencia MTTO";
            grilla_11.Columns[4].HeaderText = "Responsable MTTO";
            grilla_11.Columns[5].HeaderText = "Observaciones";

            //Ejecucion en postgresql
            grilla_11.Rows.Clear();
            NpgsqlCommand smk = new NpgsqlCommand();
            smk.CommandText = " SELECT * FROM otros_datos WHERE n9_serie = '" + serie_busqueda.Text + "';";
            smk.Connection = cn;
            NpgsqlDataReader dk = smk.ExecuteReader();
            while (dk.Read())
            {
                grilla_11.Rows.Add(dk[0], dk[1], dk[2], dk[3], dk[4], dk[5]);
            }
            dk.Close();

            //PARTE 9: Registro de Elaboración y Actualización

            grilla_12.ColumnCount = 7;
            grilla_12.Columns[0].HeaderText = "Número de Serie";
            grilla_12.Columns[1].HeaderText = "Nombre Responsable";
            grilla_12.Columns[2].HeaderText = "Cargo";
            grilla_12.Columns[3].HeaderText = "Teléfono";
            grilla_12.Columns[4].HeaderText = "Email";
            grilla_12.Columns[5].HeaderText = "Fecha";
            grilla_12.Columns[6].HeaderText = "Firma";

            //Ejecucion en postgresql
            grilla_12.Rows.Clear();
            NpgsqlCommand sml = new NpgsqlCommand();
            sml.CommandText = " SELECT * FROM registro_elab WHERE n10_serie = '" + serie_busqueda.Text + "';";
            sml.Connection = cn;
            NpgsqlDataReader dl = sml.ExecuteReader();
            while (dl.Read())
            {
                grilla_12.Rows.Add(dl[0], dl[1], dl[2], dl[3], dl[4], dl[5], dl[6]);
            }
            dl.Close();

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {
            
        }

        private void grilla_6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
