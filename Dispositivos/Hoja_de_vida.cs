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
    public partial class Hoja_de_vida : Form
    {

        NpgsqlConnection cn;


        public Hoja_de_vida()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void label100_Click(object sender, EventArgs e)
        {

        }

        private void Hoja_de_vida_Load(object sender, EventArgs e)
        {
            //Conectar a una base de datos
            string str = "Server=127.0.0.1;Port=5432;Database=Hoja_de_vida;User Id=postgres;Password=11555;";
            cn = new NpgsqlConnection();
            cn.ConnectionString = str;
            cn.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            // Validar Campos
            BorrarMensajeError();
            if (ValidarCampos())
            {
                //Descripcion del equipo
                string strSQL = "INSERT INTO equip_description VALUES ('";
                strSQL = strSQL + bien.Text + "','" + equipo.Text + "','" + marca.Text + "','" + modelo.Text + "','";
                strSQL = strSQL + serie.Text + "','" + year.Text + "')";
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro DESCRIPCION DEL BIEN ingresado correctamente");
                //Limpiar TextBox1
                bien.Text = "";
                equipo.Text = "";
                marca.Text = "";
                modelo.Text = "";
                year.Text = "";

                //Datos del equipo, valores
                string str = "insert into equip_tdata values ('";
                str = str + serie.Text + "','" + vol.Text + "','" + fase_voltaje.Text + "','" + corriente.Text + "','";
                str = str + potencia.Text + "','" + frecuencia.Text + "','" + bateria.Text + "','" + channels.Text + "','";
                str = str + memory.Text + "','" + printer.Text + "','" + observaciones_1.Text + "')";
                cmd.CommandText = str;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //se ejecuta para insert, update and delete
                MessageBox.Show("El registro DATOS TÉCNICOS ingresado correctamente");
                //Cerrar
                vol.Text = "";
                fase_voltaje.Text = "";
                corriente.Text = "";
                potencia.Text = "";
                frecuencia.Text = "";
                bateria.Text = "";
                memory.Text = "";
                printer.Text = "";
                observaciones_1.Text = "";
                channels.Text = "";


                //Datos economicos

                string str3 = "INSERT INTO datos_economicos VALUES ('";
                str3 = str3 + serie.Text + "','" + valor_adq.Text + "','" + n_factura.Text + "','" + f_adquisicion.Text + "','";
                str3 = str3 + fecha_economicos.Text + "','" + vida_util.Text + "')";
                cmd.CommandText = str3;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro DATOS ECONÓMICOS ingresado correctamente");
                //Cerrar
                valor_adq.Text = "";
                n_factura.Text = "";
                f_adquisicion.Text = "";
                fecha_economicos.Text = "";
                vida_util.Text = "";


                //Datos de ubicacion del equipo

                string str4 = "INSERT INTO ubicacion_equipo VALUES ('";
                str4 = str4 + serie.Text + "','" + unidad_op.Text + "','" + servicio.Text + "','" + sub_servicio.Text + "','";
                str4 = str4 + nombre_custodio.Text + "','" + zona.Text + "','" + distrito.Text + "','" + provincia.Text + "','";
                str4 = str4 + ciudad.Text + "')";
                cmd.CommandText = str4;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro UBICACION DEL EQUIPO ingresado correctamente");
                //Cerrar
                unidad_op.Text = "";
                servicio.Text = "";
                sub_servicio.Text = "";
                nombre_custodio.Text = "";
                zona.Text = "";
                distrito.Text = "";
                provincia.Text = "";
                ciudad.Text = "";


                //Datos proveedor 

                string str5 = "INSERT INTO datos_proveedor VALUES ('";
                str5 = str5 + serie.Text + "','" + fabricante.Text + "','" + direccion_fab.Text + "','" + telefono_fab.Text + "','" + email_fab.Text + "','";
                str5 = str5 + proveedor.Text + "','" + direccion_prov.Text + "','" + telefono_prov.Text + "','" + email_prov.Text + "','" + nombre_prov.Text + "','";
                str5 = str5 + repre_pais.Text + "','" + direccion_rep.Text + "','" + telefono_rep.Text + "','" + email_rep.Text + "','" + nombre_rep.Text + "','";
                str5 = str5 + prov_mant.Text + "','" + direccion_mant.Text + "','" + telefono_mant.Text + "','" + email_mant.Text + "','" + nombre_mant.Text + "','";
                str5 = str5 + prov_calib.Text + "','" + direccion_calib.Text + "','" + telefono_calib.Text + "','" + email_calib.Text + "','" + nombre_calib.Text + "')";
                cmd.CommandText = str5;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro DATOS DE PROVEEDOR ingresado correctamente");
                //Cerrar
                fabricante.Text = "";
                direccion_fab.Text = "";
                telefono_fab.Text = "";
                email_fab.Text = "";
                proveedor.Text = "";
                direccion_prov.Text = "";
                telefono_prov.Text = "";
                email_prov.Text = "";
                nombre_prov.Text = "";
                repre_pais.Text = "";
                direccion_rep.Text = "";
                telefono_rep.Text = "";
                email_rep.Text = "";
                nombre_rep.Text = "";
                prov_mant.Text = "";
                direccion_mant.Text = "";
                telefono_mant.Text = "";
                email_mant.Text = "";
                nombre_mant.Text = "";
                prov_calib.Text = "";
                direccion_calib.Text = "";
                telefono_calib.Text = "";
                email_calib.Text = "";
                nombre_calib.Text = "";


                // Tercera Tabla Requerimentos de funcionamiento

                string str1 = "INSERT INTO equip_requirements VALUES ('";
                str1 = str1 + serie.Text + "','" + electrico.Text + "','" + m_electrico.Text + "','" + mecanico.Text + "','" + m_mecanico.Text + "','";
                str1 = str1 + electronico.Text + "','" + m_electronico.Text + "','" + hidraulico.Text + "','" + m_hidraulico.Text + "','" + neumatico.Text + "','";
                str1 = str1 + m_neumatico.Text + "','" + electromecanico.Text + "','" + m_electromecanico.Text + "','" + vapor.Text + "','" + m_vapor.Text + "','";
                str1 = str1 + glp_1.Text + "','" + m_glp.Text + "','" + gases_medicinales.Text + "','" + m_gases_medicinales.Text + "','" + aire_comp.Text + "','";
                str1 = str1 + m_aire_comp.Text + "','" + agua_fria.Text + "','" + m_agua_fria.Text + "','" + agua_caliente.Text + "','" + m_agua_caliente.Text + "','";
                str1 = str1 + agua_desc.Text + "','" + m_agua_descalcificada.Text + "','" + otro_1.Text + "','" + m_otro.Text + "')";

                cmd.CommandText = str1;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro REQUERIMIENTOS DE FUNCIONAMIENTO ingresado correctamente");
                //Cerrar
                electrico.Text = "";
                m_electrico.Text = "";
                mecanico.Text = "";
                m_mecanico.Text = "";
                electronico.Text = "";
                m_electronico.Text = "";
                hidraulico.Text = "";
                m_hidraulico.Text = "";
                neumatico.Text = "";
                m_neumatico.Text = "";
                electromecanico.Text = "";
                m_electromecanico.Text = "";
                vapor.Text = "";
                m_vapor.Text = "";
                glp_1.Text = "";
                m_glp.Text = "";
                gases_medicinales.Text = "";
                m_gases_medicinales.Text = "";
                aire_comp.Text = "";
                m_aire_comp.Text = "";
                agua_fria.Text = "";
                m_agua_fria.Text = "";
                agua_caliente.Text = "";
                m_agua_caliente.Text = "";
                agua_desc.Text = "";
                m_agua_descalcificada.Text = "";
                otro_1.Text = "";
                m_otro.Text = "";


                // Cuarta tabla PARAMETROS MEDIDOS

                string str2 = "INSERT INTO equip_parameters VALUES ('";
                str2 = str2 + serie.Text + "','" + ecg.Text + "','" + spo2.Text + "','" + fcardiaca.Text + "','" + eeg.Text + "','";
                str2 = str2 + spco.Text + "','" + co.Text + "','" + o2.Text + "','" + apnea.Text + "','" + temperatura.Text + "','";
                str2 = str2 + fcerebral.Text + "','" + frespiratoria.Text + "','" + presioninvasiva.Text + "','" + arritmia.Text + "','" + presionnoinv.Text + "','";
                str2 = str2 + ph.Text + "','" + masa.Text + "','" + pic.Text + "','" + bis.Text + "','" + vcv.Text + "','";
                str2 = str2 + pcv.Text + "','" + simv.Text + "','" + peep.Text + "','" + psv.Text + "','" + mac.Text + "','";
                str2 = str2 + no2.Text + "','" + fio2.Text + "','" + otro_2.Text + "')";

                cmd.CommandText = str2;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro PARAMETROS MEDIDOS ingresado correctamente");
                //Cerrar
                ecg.Text = "";
                spo2.Text = "";
                fcardiaca.Text = "";
                eeg.Text = "";
                spco.Text = "";
                co.Text = "";
                o2.Text = "";
                apnea.Text = "";
                temperatura.Text = "";
                fcerebral.Text = "";
                frespiratoria.Text = "";
                presioninvasiva.Text = "";
                arritmia.Text = "";
                presionnoinv.Text = "";
                ph.Text = "";
                masa.Text = "";
                pic.Text = "";
                bis.Text = "";
                vcv.Text = "";
                pcv.Text = "";
                simv.Text = "";
                peep.Text = "";
                psv.Text = "";
                mac.Text = "";
                no2.Text = "";
                fio2.Text = "";
                otro_2.Text = "";
                // Informacion tecnica

                string str6 = "INSERT INTO info_tecnica VALUES ('";
                str6 = str6 + serie.Text + "','" + manual_op.Text + "','" + manual_inst.Text + "','" + manual_servi.Text + "','";
                str6 = str6 + manual_part.Text + "','" + otra_lit.Text + "','" + no_existe.Text + "')";

                cmd.CommandText = str6;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro INFORMACION TECNICA ingresado correctamente");
                //Cerrar
                manual_op.Text = "";
                manual_inst.Text = "";
                manual_servi.Text = "";
                manual_part.Text = "";
                otra_lit.Text = "";
                no_existe.Text = "";


                //Estado del bien

                string str7 = "INSERT INTO estado_bien VALUES ('";
                str7 = str7 + serie.Text + "','" + estatus.Text + "','" + no_operativo.Text + "','" + obs_estatus.Text + "')";

                cmd.CommandText = str7;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro ESTADO DEL BIEN ingresado correctamente");
                //Cerrar
                estatus.Text = "";
                no_operativo.Text = "";
                obs_estatus.Text = "";


                //Accesorios del equipo

                string str8 = "INSERT INTO accesorio_equipo VALUES ('";
                str8 = str8 + serie.Text + "','" + primero.Text + "','" + segundo.Text + "','" + tercero.Text + "','";
                str8 = str8 + cuarto.Text + "','" + quinto.Text + "','" + sexto.Text + "','" + estado_pr.Text + "','";
                str8 = str8 + estado_sec.Text + "','" + estado_ter.Text + "','" + estado_cu.Text + "','" + estado_qu.Text + "','";
                str8 = str8 + estado_sexto.Text + "','" + obs_accesorios.Text + "')";

                cmd.CommandText = str8;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro ACCESORIOS DEL EQUIPO ingresado correctamente");
                //Cerrar
                primero.Text = "";
                segundo.Text = "";
                tercero.Text = "";
                cuarto.Text = "";
                quinto.Text = "";
                sexto.Text = "";
                estado_pr.Text = "";
                estado_sec.Text = "";
                estado_ter.Text = "";
                estado_cu.Text = "";
                estado_qu.Text = "";
                estado_sexto.Text = "";
                obs_accesorios.Text = "";



                //Otros datos Error

                string str9 = "INSERT INTO otros_datos VALUES ('";
                str9 = str9 + serie.Text + "','" + garantia.Text + "','" + contrato.Text + "','" + frecuencia.Text + "','";
                str9 = str9 + responsable.Text + "','" + obs_otros.Text + "')";

                cmd.CommandText = str9;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro OTROS DATOS ingresado correctamente");
                //Cerrar
                garantia.Text = "";
                contrato.Text = "";
                frecuencia.Text = "";
                responsable.Text = "";
                obs_otros.Text = "";


                //Elaboracion y actualizacion

                string str10 = "INSERT INTO registro_elab VALUES ('";
                str10 = str10 + serie.Text + "','" + nombre_resp.Text + "','" + cargo_resp.Text + "','" + telefono_resp.Text + "','";
                str10 = str10 + email_resp.Text + "','" + fecha_resp.Text + "','" + firma_resp.Text + "')";

                cmd.CommandText = str10;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                MessageBox.Show("El registro REGISTRO ELABORACION ingresado correctamente");
                //Cerrar

                nombre_resp.Text = "";
                cargo_resp.Text = "";
                telefono_resp.Text = "";
                email_resp.Text = "";
                fecha_resp.Text = "";
                firma_resp.Text = "";

            }

        }

        // Validación del ingreso de datos, correción de errores 
        private bool ValidarCampos()
        {
            bool ok = true;
            //Parte 1
            if (bien.Text == "")
            {
                ok = false;
                errorProvider1.SetError(bien, "Ingresar bien");

            }

            if (equipo.Text == "")
            {
                ok = false;
                errorProvider1.SetError(equipo, "Ingresar equipo");

            }

            if (marca.Text == "")
            {
                ok = false;
                errorProvider1.SetError(marca, "Ingresar marca");

            }

            if (modelo.Text == "")
            {
                ok = false;
                errorProvider1.SetError(modelo, "Ingresar modelo");

            }

            if (serie.Text == "")
            {
                ok = false;
                errorProvider1.SetError(serie, "Ingresar serie");

            }

            if (year.Text == "")
            {
                ok = false;
                errorProvider1.SetError(year, "Ingresar año");
                
            }

            //Parte 2
            if (vol.Text == "")
            {
                ok = false;
                errorProvider1.SetError(vol, "Ingresar voltaje");

            }

            if (fase_voltaje.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fase_voltaje, "Ingresar número de fases");

            }

            if (corriente.Text == "")
            {
                ok = false;
                errorProvider1.SetError(corriente, "Ingresar corriente [A]");

            }

            if (potencia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(potencia, "Ingresar potencia [W]");

            }

            if (frecuencia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(frecuencia, "Ingresar frecuencia [Hz]");

            }

            if (bateria.Text == "")
            {
                ok = false;
                errorProvider1.SetError(bateria, "Ingresar Batería [V]");

            }

            if (memory.Text == "")
            {
                ok = false;
                errorProvider1.SetError(memory, "Ingresar Memoria");

            }

            if (printer.Text == "")
            {
                ok = false;
                errorProvider1.SetError(printer, "Ingresar Tipo de Impresora");

            }
            //Observaciones se puede evitar

            //if (observaciones_1.Text == "")
            //{
            //    ok = false;
            //   errorProvider1.SetError(observaciones_1, "Ingresar Observaciones");

            //}

            if (channels.Text == "")
            {
                ok = false;
                errorProvider1.SetError(channels, "Ingresar numero de canales");

            }

            //Parte 3

            if (valor_adq.Text == "")
            {
                ok = false;
                errorProvider1.SetError(valor_adq, "Ingresar valor de adquisición");

            }

            if (n_factura.Text == "")
            {
                ok = false;
                errorProvider1.SetError(n_factura, "Ingresar numero de factura");

            }

            if (f_adquisicion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(f_adquisicion, "Ingresar forma de adquisición");

            }

            if (fecha_economicos.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fecha_economicos, "Ingresar fecha de adquisición");

            }

            if (vida_util.Text == "")
            {
                ok = false;
                errorProvider1.SetError(vida_util, "Ingresar vida util");

            }

            //Parte 4
            if (unidad_op.Text == "")
            {
                ok = false;
                errorProvider1.SetError(unidad_op, "Ingresar unidad operacional");

            }
            if (servicio.Text == "")
            {
                ok = false;
                errorProvider1.SetError(servicio, "Ingresar servicio");

            }
            if (sub_servicio.Text == "")
            {
                ok = false;
                errorProvider1.SetError(sub_servicio, "Ingresar sub servicio");

            }
            if (nombre_custodio.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_custodio, "Ingresar nombre custodio");

            }
            if (zona.Text == "")
            {
                ok = false;
                errorProvider1.SetError(zona, "Ingresar zona");

            }
            if (distrito.Text == "")
            {
                ok = false;
                errorProvider1.SetError(distrito, "Ingresar distrito");

            }
            if (provincia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(provincia, "Ingresar provincia");

            }
            if (ciudad.Text == "")
            {
                ok = false;
                errorProvider1.SetError(ciudad, "Ingresar ciudad");

            }

            //Parte 5
            if (fabricante.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fabricante, "Ingresar fabricante");

            }
            if (direccion_fab.Text == "")
            {
                ok = false;
                errorProvider1.SetError(direccion_fab, "Ingresar direccion fabricante");

            }
            if (telefono_fab.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_fab, "Ingresar telefono fabricante");

            }
            if (email_fab.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_fab, "Ingresar email fabricante");

            }
            if (proveedor.Text == "")
            {
                ok = false;
                errorProvider1.SetError(proveedor, "Ingresar proveedor");

            }
            if (direccion_prov.Text == "")
            {
                ok = false;
                errorProvider1.SetError(direccion_prov, "Ingresar direccion proveedor");

            }
            if (telefono_prov.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_prov, "Ingresar teléfono proveedor");

            }
            if (email_prov.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_prov, "Ingresar email proveedor");

            }
            if (nombre_prov.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_prov, "Ingresar nombre proveedor");

            }
            if (repre_pais.Text == "")
            {
                ok = false;
                errorProvider1.SetError(repre_pais, "Ingresar representante pais");

            }
            if (direccion_rep.Text == "")
            {
                ok = false;
                errorProvider1.SetError(direccion_rep, "Ingresar direccion representante");

            }
            if (telefono_rep.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_rep, "Ingresar telefono representante");

            }
            if (email_rep.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_rep, "Ingresar email representante");

            }
            if (nombre_rep.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_rep, "Ingresar nombre representante");

            }
            if (prov_mant.Text == "")
            {
                ok = false;
                errorProvider1.SetError(prov_mant, "Ingresar proveedor mantenimiento");

            }
            if (direccion_mant.Text == "")
            {
                ok = false;
                errorProvider1.SetError(direccion_mant, "Ingresar direccion mantenimiento");

            }
            if (telefono_mant.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_mant, "Ingresar teléfono mantenimiento");

            }
            if (email_mant.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_mant, "Ingresar email mantenimiento");

            }
            if (nombre_mant.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_mant, "Ingresar nombre mantenimiento");

            }
            if (prov_calib.Text == "")
            {
                ok = false;
                errorProvider1.SetError(prov_calib, "Ingresar proveedor calibración");

            }
            if (direccion_calib.Text == "")
            {
                ok = false;
                errorProvider1.SetError(direccion_calib, "Ingresar direccion calibración");

            }
            if (telefono_calib.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_calib, "Ingresar telefono calibración");

            }
            if (email_calib.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_calib, "Ingresar email calibración");
            }
            if (nombre_calib.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_calib, "Ingresar nombre calibración");
            }

            //Pestaña 2
            // Parte 6
            if (electrico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(electrico, "Ingresar estatus eléctrico");
            }

            if (mecanico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(mecanico, "Ingresar estatus mecánico");
            }
            if (electronico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(electronico, "Ingresar estatus electrónico");
            }
            if (hidraulico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(hidraulico, "Ingresar estatus hidraulico");
            }
            if (neumatico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(neumatico, "Ingresar estatus neumático");
            }
            if (electromecanico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(electromecanico, "Ingresar estatus electromecánico");
            }
            if (vapor.Text == "")
            {
                ok = false;
                errorProvider1.SetError(vapor, "Ingresar estatus vapor");
            }
            if (glp_1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(glp_1, "Ingresar estatus glp");
            }
            if (gases_medicinales.Text == "")
            {
                ok = false;
                errorProvider1.SetError(gases_medicinales, "Ingresar estatus gases medicinales");
            }
            if (aire_comp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(aire_comp, "Ingresar estatus aire comprimido");
            }
            if (agua_fria.Text == "")
            {
                ok = false;
                errorProvider1.SetError(agua_fria, "Ingresar estatus agua fría");
            }
            if (agua_caliente.Text == "")
            {
                ok = false;
                errorProvider1.SetError(agua_caliente, "Ingresar estatus agua caliente");
            }
            if (agua_desc.Text == "")
            {
                ok = false;
                errorProvider1.SetError(agua_desc, "Ingresar estatus agua descalcificada");
            }
            if (otro_1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(otro_1, "Ingresar estatus otro");
            }
            //Parte 7
            if (ecg.Text == "")
            {
                ok = false;
                errorProvider1.SetError(ecg, "Ingresar ecg");
            }
            if (spo2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(spo2, "Ingresar spo2");
            }
            if (fcardiaca.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fcardiaca, "Ingresar F.cardiaca");
            }
            if (eeg.Text == "")
            {
                ok = false;
                errorProvider1.SetError(eeg, "Ingresar eeg");
            }
            if (spco.Text == "")
            {
                ok = false;
                errorProvider1.SetError(spco, "Ingresar spco");
            }
            if (co.Text == "")
            {
                ok = false;
                errorProvider1.SetError(co, "Ingresar CO");
            }
            if (o2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(o2, "Ingresar 02");
            }
            if (apnea.Text == "")
            {
                ok = false;
                errorProvider1.SetError(apnea, "Ingresar Apnea");
            }
            if (temperatura.Text == "")
            {
                ok = false;
                errorProvider1.SetError(temperatura, "Ingresar Temperatura");
            }
            if (fcerebral.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fcerebral, "Ingresar F.cerebral");
            }
            if (frespiratoria.Text == "")
            {
                ok = false;
                errorProvider1.SetError(frespiratoria, "Ingresar F.respiratoria");
            }
            if (presioninvasiva.Text == "")
            {
                ok = false;
                errorProvider1.SetError(presioninvasiva, "Ingresar Presion Invasiva");
            }
            if (arritmia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(arritmia, "Ingresar arritmia");
            }
            if (presionnoinv.Text == "")
            {
                ok = false;
                errorProvider1.SetError(presionnoinv, "Ingresar presion no inv");
            }
            if (ph.Text == "")
            {
                ok = false;
                errorProvider1.SetError(ph, "Ingresar ph");
            }
            if (masa.Text == "")
            {
                ok = false;
                errorProvider1.SetError(masa, "Ingresar masa");
            }
            if (pic.Text == "")
            {
                ok = false;
                errorProvider1.SetError(pic, "Ingresar pic");
            }
            if (bis.Text == "")
            {
                ok = false;
                errorProvider1.SetError(bis, "Ingresar bis");
            }
            if (vcv.Text == "")
            {
                ok = false;
                errorProvider1.SetError(vcv, "Ingresar vcv");
            }
            if (pcv.Text == "")
            {
                ok = false;
                errorProvider1.SetError(pcv, "Ingresar pcv");
            }
            if (simv.Text == "")
            {
                ok = false;
                errorProvider1.SetError(simv, "Ingresar simv");
            }
            if (peep.Text == "")
            {
                ok = false;
                errorProvider1.SetError(peep, "Ingresar peep");
            }
            if (psv.Text == "")
            {
                ok = false;
                errorProvider1.SetError(psv, "Ingresar psv");
            }
            if (mac.Text == "")
            {
                ok = false;
                errorProvider1.SetError(mac, "Ingresar mac");
            }
            if (no2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(no2, "Ingresar no2");
            }
            if (fio2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fio2, "Ingresar fio2");
            }
            if (otro_2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(otro_2, "Ingresar otro");
            }
            //Parte 8
            if (manual_op.Text == "")
            {
                ok = false;
                errorProvider1.SetError(manual_op, "Ingresar manual");
            }

            if (manual_inst.Text == "")
            {
                ok = false;
                errorProvider1.SetError(manual_inst, "Ingresar manual inst.");
            }
            if (manual_servi.Text == "")
            {
                ok = false;
                errorProvider1.SetError(manual_servi, "Ingresar manual serv.");
            }
            if (manual_part.Text == "")
            {
                ok = false;
                errorProvider1.SetError(manual_part, "Ingresar manual part.");
            }
            if (otra_lit.Text == "")
            {
                ok = false;
                errorProvider1.SetError(otra_lit, "Ingresar otro literatura");
            }
            if (no_existe.Text == "")
            {
                ok = false;
                errorProvider1.SetError(otra_lit, "Ingresar ");
            }
            //Parte 9
            if (estatus.Text == "")
            {
                ok = false;
                errorProvider1.SetError(estatus, "Ingresar estatus");
            }

            // no_operativo.Text == ""
            // obs_estatus.Text = "";

            //Parte 10

            //No es necesario que llenen todos los campos

            //Parte 11

            if (garantia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(garantia, "Ingresar garantia");
            }
            if (contrato.Text == "")
            {
                ok = false;
                errorProvider1.SetError(contrato, "Ingresar contrato");
            }
            if (frecuencia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(frecuencia, "Ingresar frecuencia");
            }
            if (responsable.Text == "")
            {
                ok = false;
                errorProvider1.SetError(responsable, "Ingresar responsable");
            }

            //Parte 12

            if (nombre_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_resp, "Ingresar nombre responsable");
            }
            if (cargo_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(cargo_resp, "Ingresar cargo responsable");
            }
            if (telefono_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_resp, "Ingresar telefono responsable");
            }
            if (email_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_resp, "Ingresar email responsable");
            }
            if (fecha_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fecha_resp, "Ingresar fecha emision");
            }
            if (firma_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(firma_resp, "Ingresar firma");
            }
            
            MessageBox.Show("Error al ingreso de datos. Verifique que los datos sean los correctos", "Advertencia");
            return ok;

        }

        // Borrar el mensaje de error de la casilla
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(bien, "");
            errorProvider1.SetError(equipo, "");
            errorProvider1.SetError(marca, "");
            errorProvider1.SetError(modelo, "");
            errorProvider1.SetError(serie, "");
            errorProvider1.SetError(year, "");
            //Parte 2
            errorProvider1.SetError(vol, "");
            errorProvider1.SetError(fase_voltaje, "");
            errorProvider1.SetError(corriente, "");
            errorProvider1.SetError(potencia, "");
            errorProvider1.SetError(frecuencia, "");
            errorProvider1.SetError(bateria, "");
            errorProvider1.SetError(memory, "");
            errorProvider1.SetError(observaciones_1, "");
            errorProvider1.SetError(channels, "");
            //Parte 3
            errorProvider1.SetError(valor_adq, "");
            errorProvider1.SetError(n_factura, "");
            errorProvider1.SetError(f_adquisicion, "");
            errorProvider1.SetError(fecha_economicos, "");
            errorProvider1.SetError(vida_util, "");
            //Parte 4
            errorProvider1.SetError(unidad_op, "");
            errorProvider1.SetError(servicio, "");
            errorProvider1.SetError(sub_servicio, "");
            errorProvider1.SetError(nombre_custodio, "");
            errorProvider1.SetError(zona, "");
            errorProvider1.SetError(distrito, "");
            errorProvider1.SetError(provincia, "");
            errorProvider1.SetError(ciudad, "");
            //Parte 5
            errorProvider1.SetError(fabricante, "");
            errorProvider1.SetError(direccion_fab, "");
            errorProvider1.SetError(telefono_fab, "");
            errorProvider1.SetError(email_fab, "");
            errorProvider1.SetError(proveedor, "");
            errorProvider1.SetError(direccion_prov, "");
            errorProvider1.SetError(telefono_prov, "");
            errorProvider1.SetError(email_prov, "");
            errorProvider1.SetError(telefono_prov, "");
            errorProvider1.SetError(nombre_prov, "");
            errorProvider1.SetError(repre_pais, "");
            errorProvider1.SetError(direccion_rep, "");
            errorProvider1.SetError(telefono_rep, "");
            errorProvider1.SetError(email_rep, "");
            errorProvider1.SetError(nombre_rep, "");
            errorProvider1.SetError(email_rep, "");
            errorProvider1.SetError(prov_mant, "");
            errorProvider1.SetError(direccion_mant, "");
            errorProvider1.SetError(telefono_mant, "");
            errorProvider1.SetError(email_mant, "");
            errorProvider1.SetError(nombre_mant, "");
            errorProvider1.SetError(prov_calib, "");
            errorProvider1.SetError(direccion_calib, "");
            errorProvider1.SetError(telefono_calib, "");
            errorProvider1.SetError(email_calib, "");
            errorProvider1.SetError(nombre_calib, "");
            //Parte 6
            errorProvider1.SetError(electrico, "");
            errorProvider1.SetError(mecanico, "");
            errorProvider1.SetError(electronico, "");
            errorProvider1.SetError(hidraulico, "");
            errorProvider1.SetError(neumatico, "");
            errorProvider1.SetError(electromecanico, "");
            errorProvider1.SetError(vapor, "");
            errorProvider1.SetError(glp_1, "");
            errorProvider1.SetError(gases_medicinales, "");
            errorProvider1.SetError(aire_comp, "");
            errorProvider1.SetError(agua_fria, "");
            errorProvider1.SetError(agua_caliente, "");
            errorProvider1.SetError(agua_desc, "");
            errorProvider1.SetError(gases_medicinales, "");
            errorProvider1.SetError(otro_1, "");
            //Parte 7

            errorProvider1.SetError(ecg, "");
            errorProvider1.SetError(spo2, "");
            errorProvider1.SetError(fcardiaca, "");
            errorProvider1.SetError(eeg, "");
            errorProvider1.SetError(spco, "");
            errorProvider1.SetError(co, "");
            errorProvider1.SetError(o2, "");
            errorProvider1.SetError(apnea, "");
            errorProvider1.SetError(temperatura, "");
            errorProvider1.SetError(fcerebral, "");
            errorProvider1.SetError(frespiratoria, "");
            errorProvider1.SetError(presioninvasiva, "");
            errorProvider1.SetError(arritmia, "");
            errorProvider1.SetError(presionnoinv, "");
            errorProvider1.SetError(ph, "");
            errorProvider1.SetError(masa, "");
            errorProvider1.SetError(pic, "");
            errorProvider1.SetError(bis, "");
            errorProvider1.SetError(vcv, "");
            errorProvider1.SetError(pcv, "");
            errorProvider1.SetError(simv, "");
            errorProvider1.SetError(peep, "");
            errorProvider1.SetError(psv, "");
            errorProvider1.SetError(mac, "");
            errorProvider1.SetError(no2, "");
            errorProvider1.SetError(fio2, "");
            errorProvider1.SetError(otro_2, "");
            //Parte 8
            errorProvider1.SetError(manual_op, "");
            errorProvider1.SetError(manual_inst, "");
            errorProvider1.SetError(manual_servi, "");
            errorProvider1.SetError(manual_part, "");
            errorProvider1.SetError(otra_lit, "");
            errorProvider1.SetError(no_existe, "");
            //Parte 9
            errorProvider1.SetError(estatus, "");
            //Parte 10

            //Parte 11
            errorProvider1.SetError(garantia, "");
            errorProvider1.SetError(contrato, "");
            errorProvider1.SetError(frecuencia, "");
            errorProvider1.SetError(responsable, "");
            //Parte 12
            errorProvider1.SetError(nombre_resp, "");
            errorProvider1.SetError(cargo_resp, "");
            errorProvider1.SetError(telefono_resp, "");
            errorProvider1.SetError(email_resp, "");
            errorProvider1.SetError(fecha_resp, "");
            errorProvider1.SetError(firma_resp, "");
        }


        private void observaciones_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void subirimg_Click(object sender, EventArgs e)
        {
           
        }

        private void year_Validating(object sender, CancelEventArgs e)
        {

        }

        // Mensajes de advertencia dependiendo al tipo de dato

        private void year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void vol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void corriente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void frecuencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void potencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void bateria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void channels_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void n_factura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void telefono_fab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void telefono_prov_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void telefono_rep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void telefono_mant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void telefono_calib_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void telefono_resp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
