using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Vehiculos
    {

        CD_Conexion db_conexion = new CD_Conexion();
        //private object cmdUspActualizar;

        public DataTable MtMostrarVehiculos()
        {
            string QryMostrarClientes = "usp_vehiculos_select";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarClientes, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarClientes = new DataTable();
            adapter.Fill(dtMostrarClientes);
            db_conexion.MtdCerrarConexion();
            return dtMostrarClientes;
        }
        public void mtdAgregaraVehiculos(string Marca, string Modelo, int Año, decimal Precio, string Estado)
        {


            string usp_Insertar = "usp_vehiculos_insertar";
            SqlCommand cmd_InsertarVehiculos = new SqlCommand(usp_Insertar, db_conexion.MtdAbrirConexion());
           
            cmd_InsertarVehiculos.CommandType = CommandType.StoredProcedure;
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Marca", Marca);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Modelo", Modelo);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Año", Año);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Precio", Precio);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Estado", Estado);

            cmd_InsertarVehiculos.ExecuteNonQuery();


        }

        public void MtdActualizarVehiculos( int Vehiculos, string Marca, string Modelo, int año, decimal Precio, string Estado)
        {

            string usp_actualizar = "usp_vehiculos_update";
            SqlCommand cmd_UspActualizar = new SqlCommand(usp_actualizar, db_conexion.MtdAbrirConexion());
            cmd_UspActualizar.CommandType = CommandType.StoredProcedure;
            cmd_UspActualizar.CommandType = CommandType.StoredProcedure;
            cmd_UspActualizar.Parameters.AddWithValue("@VehiculoID", Vehiculos);
            cmd_UspActualizar.Parameters.AddWithValue("@Marca", Marca);
            cmd_UspActualizar.Parameters.AddWithValue("@Modelo", Modelo);
            cmd_UspActualizar.Parameters.AddWithValue("@Año", año);
            cmd_UspActualizar.Parameters.AddWithValue("@Precio", Precio);
            cmd_UspActualizar.Parameters.AddWithValue("@Estado", Estado);

            cmd_UspActualizar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();
        }


        public void MtdEliminarVehiculos(int Codigo)
        {
            string usp_eliminar = "usp_vehiculos_delete";
            SqlCommand cmdUspEliminar = new SqlCommand(usp_eliminar, db_conexion.MtdAbrirConexion());
            cmdUspEliminar.CommandType = CommandType.StoredProcedure;
            cmdUspEliminar.Parameters.AddWithValue("@VehiculoID", Codigo);
            cmdUspEliminar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();
        }
    }
}
