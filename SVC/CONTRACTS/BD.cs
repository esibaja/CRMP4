using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using DAL.BD;
using BLL.BD;
using System.Data;

namespace SVC.CONTRACTS
{
    public class BD : INTERFACES.IBD
    {
        public DataTable Get_DT_Param(DataTable DT_Param)
        {
            DT_Param = new DataTable("PARAMETROS");
            DT_Param.Columns.Add("Nom_Param"); //COLUMNA 0
            DT_Param.Columns.Add("Tipo_Dato_Param"); //COLUMNA 1
            DT_Param.Columns.Add("Valor_Param"); //COLUMNA 2

            return DT_Param;
        }

        public DataTable ListarFiltrar(string sNombreTabla, string sNombreSP, DataTable DT_Param)
        {
            cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
            cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

            Obj_BD_DAL.sNomSP = sNombreSP;
            Obj_BD_DAL.sNomTabla = sNombreTabla;
            Obj_BD_DAL.DT_Parametros = DT_Param;

            Obj_BD_BLL.ExecDataAdapter(ref Obj_BD_DAL);

            if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
            {
                return Obj_BD_DAL.DS.Tables[0];
            }
            else
            {
                return null;
            }            
        }

        public string Ins_Upd_Delete(string sNombreSP, string sIndAxn, DataTable DT_Param)
        {
            cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
            cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

            Obj_BD_DAL.sNomSP = sNombreSP;
            Obj_BD_DAL.sIndAxn = sIndAxn;
            Obj_BD_DAL.DT_Parametros = DT_Param;

            Obj_BD_BLL.ExecCommand(ref Obj_BD_DAL);

            if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
            {
                return Obj_BD_DAL.sValorScalar;
            }
            else
            {
                return null;
            }
        }
    }
}
