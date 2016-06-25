using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clase4.Clases;

namespace Clase4
{
    public partial class frmRegistro : Form
    {
        public List<Persona> Personas { get; set; }

        public frmRegistro()
        {
            InitializeComponent();

            Personas = new List<Persona>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Persona persona;

            if (chkEmpleado.Checked)
            {
                var empleado = new Empleado();
                empleado.Sueldo = Convert.ToDouble(txtSueldo.Text);

                persona = empleado;
            }
            else
            {
                persona = new Persona();
            }

            persona.Nombre = txtNombre.Text;
            persona.Sexo = cbSexo.Text;
            persona.FechaNacimiento = txtFechaNacimiento.Value;

            Personas.Add(persona);

            LimpiarCampos();
            ContarPersonasSueldos();

            /*
            MessageBox.Show(
                "Hola " + persona.Nombre + ", tiene " + persona.Edad + " anios",
                "Mensaje"); */
        }

        private void ContarPersonasSueldos()
        {
            lblCantidad.Text = Personas.Count.ToString();

            double sueldoTotal = 0;

            // Recorremos todas las personas que hemos agregado a la lista.
            foreach (var persona in Personas)
            {
                // Si es un empleado
                if (persona is Empleado)
                {
                    // La sentencia "as" convierte un objeto en un tipo COMPATIBLE.
                    // Se recomienda validar con "is" antes de convertir.
                    sueldoTotal += (persona as Empleado).Sueldo;
                }
            }

            // El formato "N2" nos da un valor en notación numérica con 2 decimales
            // e incluye la comas.
            lblSueldos.Text = sueldoTotal.ToString("N2");
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            cbSexo.Text = "";
            txtSueldo.Text = "";
            txtFechaNacimiento.Value = DateTime.Today;
            chkEmpleado.Checked = true;
        }

        private void chkEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            lblSueldo.Visible = chkEmpleado.Checked;
            txtSueldo.Visible = chkEmpleado.Checked;
        }
    }
}
