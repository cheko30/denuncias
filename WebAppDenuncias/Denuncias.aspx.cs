using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebAppDenuncias.model;
using System.Data.SqlClient;
using System.Drawing;


namespace WebAppDenuncias
{
    public partial class Denuncias : System.Web.UI.Page
    {   
        
        Conexion conexion;
        static int idDenuncia = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion();
            if (!IsPostBack)
            {
                listarTipos();
                listarDenuncias();
            }

        }

        private void listarDenuncias()
        {
            string sql = "SELECT d.id AS 'Folio', d.descripcion AS 'Descripción', d.fechaSuceso AS 'Fecha', d.fechaRegistro, td.id, td.descripcion AS 'Delito', u.nombre + ' ' + u.apellidoPaterno + ' ' + u.apellidoMaterno AS 'nombre' FROM denuncias d INNER JOIN catEstatus e ON e.id = d.statusFK INNER JOIN catTipoDenuncias td ON td.id = d.tipoDenunciaFK INNER JOIN usuarios u ON u.id = d.usuarioFK";
            DataSet dataSet = conexion.getData(sql);
            if(dataSet.Tables[0].Rows.Count > 0)
            {
                grdListaDenuncias.DataSource = dataSet;
                grdListaDenuncias.DataBind();
            }

        }

        private void listarTipos()
        {
            string sql = "SELECT id, descripcion FROM catTipoDenuncias";
            DataSet dataSet = conexion.getData(sql);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                drpTipo.DataSource = dataSet;
                drpTipo.DataValueField = "id";
                drpTipo.DataTextField = "descripcion";
                drpTipo.DataBind();
            }           
        }

        protected void btnGuardarClick(object sender, EventArgs e)
        {
            DenunciaModel denunciaModel = new DenunciaModel();
            denunciaModel.fechaSuceso = (Convert.ToDateTime(txtFechaSuceso.Text)).ToString("yyyy-MM-dd hh:mm:ss");
            denunciaModel.descripcion = txtDescripcion.Text;
            denunciaModel.statusFK = (int)Estatus.Activo;
            denunciaModel.usuarioFK = Convert.ToInt32(txtUsuario.Text);
            denunciaModel.tipoDenunciaFK = Convert.ToInt32(drpTipo.SelectedValue);

            if (registrarDenuncia(denunciaModel,1))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(true, 'La denuncia se registro con éxito');", true);
                listarDenuncias();
                limpiarControles();

            } 
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(false, 'Ocurrio un error al registrar la denuncia');", true);
            }

        }

        private void limpiarControles()
        {
            txtDescripcion.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtFechaSuceso.Text = string.Empty;
            drpTipo.SelectedIndex = 0;
        }

        private bool registrarDenuncia(DenunciaModel denunciaModel, int operacion)
        {
            
            List<SqlParameter> listParametros = new List<SqlParameter>();
            listParametros.Add(new SqlParameter("@opcion", SqlDbType.Int) { Value = operacion });
            listParametros.Add(new SqlParameter("@fechaSuceso", SqlDbType.NVarChar) { Value = denunciaModel.fechaSuceso });
            listParametros.Add(new SqlParameter("@descripcion", SqlDbType.NVarChar) { Value = denunciaModel.descripcion });
            listParametros.Add(new SqlParameter("@statusFK", SqlDbType.Int) { Value = denunciaModel.statusFK });
            listParametros.Add(new SqlParameter("@tipoDenunciaFK", SqlDbType.Int) { Value = denunciaModel.tipoDenunciaFK });
            listParametros.Add(new SqlParameter("@usuarioFK", SqlDbType.Int) { Value = denunciaModel.usuarioFK });
            listParametros.Add(new SqlParameter("@idDenuncia", SqlDbType.Int) { Value = denunciaModel.id });
            return conexion.iudData("spDenuncias", listParametros.ToArray());
            
        }

        protected void lnkEliminar(object sender, CommandEventArgs e)
        {
            if (eliminarDenuncia(Convert.ToInt32(e.CommandArgument)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(true, 'La denuncia se elimino correctamente');", true);
                listarDenuncias();
                limpiarControles();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(false, 'Ocurrio un error al eliminar la denuncia');", true);
                listarDenuncias();
                limpiarControles();
            }

        }

        private bool eliminarDenuncia(int id)
        {
            List<SqlParameter> listParametros = new List<SqlParameter>();
            listParametros.Add(new SqlParameter("@opcion", SqlDbType.Int) { Value = 2 });
            listParametros.Add(new SqlParameter("@idDenuncia", SqlDbType.Int) { Value = id });
            return conexion.iudData("spDenuncias", listParametros.ToArray());
            
        }

        protected void grdListaDenuncias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow fila = (GridViewRow)(((LinkButton) e.CommandSource).NamingContainer);
            if (e.CommandName.Equals("editar"))
            {
                idDenuncia = Convert.ToInt32(fila.Cells[2].Text);
                txtDescripcion.Text = fila.Cells[3].Text;
                txtFechaSuceso.Text = Convert.ToDateTime(fila.Cells[4].Text).ToString("yyyy-MM-ddTHH:mm:ss");
                drpTipo.SelectedIndex = Convert.ToInt32(fila.Cells[6].Text);
                txtFolio.Text = Convert.ToString(idDenuncia);
                lblFolio.Visible = true;
                txtFolio.Visible = true;
                txtFolio.Enabled = false;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
            }

        }

        protected void btnEditarClick(object sender, EventArgs e)
        {
            DenunciaModel denunciaModel = new DenunciaModel();
            denunciaModel.fechaSuceso = (Convert.ToDateTime(txtFechaSuceso.Text)).ToString("yyyy-MM-dd hh:mm:ss");
            denunciaModel.descripcion = txtDescripcion.Text;
            denunciaModel.statusFK = (int)Estatus.Activo;
            denunciaModel.tipoDenunciaFK = Convert.ToInt32(drpTipo.SelectedValue);
            denunciaModel.id = Convert.ToInt32(txtFolio.Text);

            if (registrarDenuncia(denunciaModel, 3))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(true, 'La denuncia se actualizo correctamente');", true);
                listarDenuncias();
                limpiarControles();
                lblFolio.Visible = false;
                txtFolio.Visible = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(false, 'Ocurrio un error al actualizar la denuncia');", true);
            }
        }

        protected void grdListaDenuncias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[8].Visible = false;
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Console.WriteLine(e.Row.Cells[5].Text);

                if(e.Row.Cells[6].Text == "3")
                {
                    e.Row.BackColor = Color.LightCyan;
                }
                {

                }
            }
        }
    }
}