using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Datos;

namespace Capa_Presentacion
{
    public partial class FrmVehiculos : Form
    {
        public FrmVehiculos()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            MtdMostrarV();

        }
        public void MtdMostrarV()
        {
            CD_Vehiculos cd_clientes = new CD_Vehiculos();
            DataTable dtMostrarClientes = cd_clientes.MtMostrarVehiculos();
            dgvVehiculos.DataSource = dtMostrarClientes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIdVehiculos.ResetText();
            txtMarca.ResetText();
            txtModelo.ResetText();
            txtAño.ResetText();
            txtPrecio.ResetText();
            cboxEstado.ResetText();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CD_Vehiculos vehiculo = new CD_Vehiculos();

            try
            {
                vehiculo.MtdActualizarVehiculos( 
                    int.Parse(txtIdVehiculos.Text),
                    txtMarca.Text,                   
                    txtModelo.Text,                  
                    int.Parse(txtAño.Text),      
                    decimal.Parse(txtPrecio.Text),        
                    cboxEstado.Text
                       ); 
                MessageBox.Show("El   Vehiculo se actualizo con éxito", "Correcto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MtdMostrarV();
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que la fila seleccionada sea válida
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvVehiculos.Rows[e.RowIndex];

                // Asigna los valores de la fila seleccionada a los TextBox
                txtIdVehiculos.Text = fila.Cells["VehiculoID"].Value.ToString();
                txtMarca.Text = fila.Cells["Marca"].Value.ToString();
                txtModelo.Text = fila.Cells["Modelo"].Value.ToString();
                txtAño.Text = fila.Cells["Año"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                cboxEstado.Text = fila.Cells["Estado"].Value.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CD_Vehiculos vehiculo = new CD_Vehiculos();

            try
            {
                vehiculo.mtdAgregaraVehiculos
                 (
                   
                    txtMarca.Text,
                    txtModelo.Text,
                    int.Parse(txtAño.Text),
                    decimal.Parse(txtPrecio.Text),
                    cboxEstado.Text

                 );
                MessageBox.Show("El Vehiculo se agrefado con éxito", "Correcto",
               MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            MtdMostrarV();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvVehiculos.SelectedRows.Count > 0)
            {
                int vehiculoId = Convert.ToInt32(dgvVehiculos.SelectedRows[0].Cells["VehiculoID"].Value);
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este vehículo?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    CD_Vehiculos vehiculo = new CD_Vehiculos();
                    vehiculo.MtdEliminarVehiculos(vehiculoId);

                    // Volver a cargar los vehículos después de eliminar
                    MtdMostrarV();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un vehículo para eliminar.");
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
