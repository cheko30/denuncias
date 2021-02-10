using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDenuncias.model;

namespace WebAppDenuncias
{
    public partial class ListDenuncias : Page
    {
        Conexion conexion;
        Usuario usuario;
        int rol;

        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion();

            if (Session["dataUser"] != null)
            {
                usuario = (Usuario)Session["dataUser"];
                rol = usuario.rolFK;
            }

            if (!IsPostBack)
            {
                listarDenuncias();
            }
        }

        private void listarDenuncias()
        {
            if (rol > 0)
            {
                string sp = "spDenuncias";
                Denuncias denuncias = new Denuncias();
                List<SqlParameter> listParameters = new List<SqlParameter>();
                listParameters.Add(new SqlParameter("@opcion", SqlDbType.Int) { Value = 4 });
                DataSet dataSet = conexion.getData(sp, listParameters.ToArray());
                if (dataSet.Tables.Count > 0)
                {
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        grdListaDenuncias.DataSource = dataSet;
                        grdListaDenuncias.DataBind();
                    }
                }

            }
        }

        protected void grdListaDenuncias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[8].Visible = false;*/
            e.Row.Cells[4].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[6].Text == "5")
                {
                    e.Row.BackColor = Color.LightCyan;
                }
            }
        }

        protected void grdListaDenuncias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            /*
            GridViewRow fila = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
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
            */

        }
    }
}