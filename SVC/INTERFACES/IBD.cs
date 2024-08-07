using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;

namespace SVC.INTERFACES
{
    [ServiceContract]

    public interface IBD
    {
        [OperationContract]
        DataTable Get_DT_Param(DataTable DT_Param);


        [OperationContract]
        DataTable ListarFiltrar(string sNombreTabla, string sNombreSP, DataTable DT_Param);


        [OperationContract]
        string Ins_Upd_Delete(string sNombreSP, string sIndAxn, DataTable DT_Param);
    }
}
