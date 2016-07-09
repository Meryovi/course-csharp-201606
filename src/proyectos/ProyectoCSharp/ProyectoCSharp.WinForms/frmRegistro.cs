using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProyectoCSharp.Libreria.Modelos;
using ProyectoCSharp.Libreria.Repositorios;

namespace Clase4
{
    public partial class frmRegistro : Form
    {
        // Esta Lista almacena las personas registradas
        public List<Persona> Personas { get; private set; }

        // Repositorio de personas
        public IRepositorioPersonas Repositorio { get; private set; }

        public frmRegistro()
        {
            InitializeComponent();

            // Inicializamos la lista en blanco.
            Repositorio = new RepositorioPersonasEF();
            Personas = Repositorio.BuscarPersonas();

            ContarPersonasSueldos();
        }

        /// <summary>
        /// Evento que se dispara cuando se hace clic en el botón de registrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var persona = new Persona();

            // Copiamos los campos del formulario hacia la persona.
            persona.Identificacion = txtIdentificacion.Text;
            persona.Nombre = txtNombre.Text;
            persona.Sexo = cbSexo.Text;
            persona.EsEmpleado = chkEmpleado.Checked;
            persona.FechaNacimiento = txtFechaNacimiento.Value;

            if (!String.IsNullOrEmpty(txtSueldo.Text))
                persona.Sueldo = Convert.ToDecimal(txtSueldo.Text);

            // Agregamos la persona a la lista de personas.
            Personas.Add(persona);
            Repositorio.RegistrarPersona(persona);

            // Limpiamos los campos y calculamos los valores que mostramos.
            LimpiarCampos();
            ContarPersonasSueldos();
        }

        /// <summary>
        /// Muestra la cantidad de personas registradas y sus sueldos
        /// </summary>
        private void ContarPersonasSueldos()
        {
            // Coloca en el label lblCantidad la cantidad de personas registradas.
            lblCantidad.Text = Personas.Count.ToString();

            // Mas abajo sumamos el total de sueldo de todas las personas
            // que son empleados.

            decimal sueldoTotal = 0;

            // Recorremos todas las personas que hemos agregado a la lista.
            foreach (var persona in Personas)
            {
                // Si es un empleado.
                // Se valida si es una instancia de Empleado utilizando la sentencia "is".
                if (persona.EsEmpleado)
                {
                    // La sentencia "as" convierte un objeto en un tipo COMPATIBLE.
                    // Se recomienda validar con "is" antes de convertir.
                    sueldoTotal += persona.Sueldo.GetValueOrDefault();
                }
            }

            // El formato "N2" nos da un valor en notación numérica con 2 decimales
            // e incluye la comas.
            lblSueldos.Text = sueldoTotal.ToString("N2");
        }

        /// <summary>
        /// Este método limpia los campos del formulario para que puedan ser completados
        /// nuevamente por el usuario
        /// </summary>
        private void LimpiarCampos()
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            cbSexo.Text = "";
            txtSueldo.Text = "";
            txtFechaNacimiento.Value = DateTime.Today;
            chkEmpleado.Checked = true;
        }

        /// <summary>
        /// Este evento se dispara cuando se cambia el valor del CheckBox chkEmpleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            // El label y textbox del sueldo son visibles si chkEmpleado esta marcado.
            lblSueldo.Visible = chkEmpleado.Checked;
            txtSueldo.Visible = chkEmpleado.Checked;
        }
    }
}