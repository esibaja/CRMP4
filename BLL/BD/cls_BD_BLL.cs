﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------------------
using System.Data;
using System.Data.SqlClient;
using System.Configuration; // es el que nos pemite leer valores del app.config o el web.config
using DAL.BD;
//-----------------------------

namespace BLL.BD
{
   public class cls_BD_BLL
    {
        /// <summary>
        /// ES EL METODO POR MEDIO DEL CUAL YO VOY A EJECUTAR LAS ACCIONES DE LISTAR Y FILTRAR 
        /// # 1 - LISTAR ES ( SELECT SIN WHERE ) -- NO LLEVA PARAMETROS
        /// # 2 - FILTRAR ES ( SELECT CON WHERE ) -- LLEVA AL MENOS 1 PARAMETRO
        /// </summary>
        /// <param name="Obj_BD_DAL">RECIBE EL OBJETO DEL TIPO DE LA CLASE BD DEL PROYECTO DAL</param>
        public void ExecDataAdapter(ref cls_BD_DAL Obj_BD_DAL)
        {
            try
            {
                Obj_BD_DAL.Obj_CNX = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL_AUT"].ToString());

                if (Obj_BD_DAL.Obj_CNX.State == ConnectionState.Closed)
                {
                    Obj_BD_DAL.Obj_CNX.Open();
                }

                Obj_BD_DAL.Obj_DAP = new SqlDataAdapter(Obj_BD_DAL.sNomSP,    // nombre del store procedure que debe ejecutar en la BD
                                                        Obj_BD_DAL.Obj_CNX); // conexion a la BD previamente costruida y abierta.

                Obj_BD_DAL.Obj_DAP.SelectCommand.CommandType = CommandType.StoredProcedure;

                #region AGREGAR PARÁMETROS

                    if (Obj_BD_DAL.DT_Parametros != null)
                    {
                        SqlDbType TipoDatoSQL = SqlDbType.VarChar;

                        foreach (DataRow dr in Obj_BD_DAL.DT_Parametros.Rows)
                        {
                            #region Definición de tipos de Datos del SQL

                                switch (dr[1])
                                {
                                    case "1":
                                        {
                                            TipoDatoSQL = SqlDbType.Int;
                                            break;
                                        }
                                    case "2":
                                        {
                                            TipoDatoSQL = SqlDbType.Decimal;
                                            break;
                                        }
                                    case "3":
                                        {
                                            TipoDatoSQL = SqlDbType.Float;
                                            break;
                                        }
                                    case "4":
                                        {
                                            TipoDatoSQL = SqlDbType.Char;
                                            break;
                                        }
                                    case "5":
                                        {
                                            TipoDatoSQL = SqlDbType.NChar;
                                            break;
                                        }
                                    case "6":
                                        {
                                            TipoDatoSQL = SqlDbType.VarChar;
                                            break;
                                        }
                                    case "7":
                                        {
                                            TipoDatoSQL = SqlDbType.NVarChar;
                                            break;
                                        }
                                    case "8":
                                        {
                                            TipoDatoSQL = SqlDbType.DateTime;
                                            break;
                                        }
                                    case "9":
                                        {
                                            TipoDatoSQL = SqlDbType.Bit;
                                            break;
                                        }
                                    case "10":
                                        {
                                            TipoDatoSQL = SqlDbType.Money;
                                            break;
                                        }
                                    case "11":
                                        {
                                            TipoDatoSQL = SqlDbType.TinyInt;
                                            break;
                                        }

                                    default:
                                                break;
                                }

                            #endregion

                            Obj_BD_DAL.Obj_DAP.SelectCommand.Parameters.Add(dr[0].ToString(),             // nombre del parametro
                                                                            TipoDatoSQL                  // el tipo de datos que entiende el sql - resultado del switch
                                                                            ).Value = dr[2].ToString(); // el valor del parametro

                        }
                    }

                #endregion

                Obj_BD_DAL.DS = new DataSet();
                Obj_BD_DAL.Obj_DAP.Fill(Obj_BD_DAL.DS,          // objeto donde el sql va a devolver los datos resultado de la ejecución del SP
                                        Obj_BD_DAL.sNomTabla); // nombre técnico del data tables en programació o código

                Obj_BD_DAL.sMsjErrorBD = string.Empty;
            }
            catch (SqlException ex)
            {
                Obj_BD_DAL.sMsjErrorBD = ex.Message.ToString();
            }
            finally
            {
                if (Obj_BD_DAL.Obj_CNX.State == ConnectionState.Open)
                {
                    Obj_BD_DAL.Obj_CNX.Close();
                }

                Obj_BD_DAL.Obj_CNX.Dispose();
            }
        }
        /// <summary>
        /// ES EL METODO POR MEDIO DEL CUAL YO VOY A EJECUTAR Crear, Modificar,Borrar
        /// # 1 - Crear Nuevo es Insert Si requiere parametros, la cantidad que requiera el insert
        /// # 2 - Modificar
        /// # 3 - Eliminar (Delete) Requiere parametros
        /// </summary>
        /// <param name="Obj_BD_DAL">RECIBE EL OBJETO DEL TIPO DE LA CLASE BD DEL PROYECTO DAL</param>
        public void ExecCommand(ref cls_BD_DAL Obj_BD_DAL)
        {
            try
            {
                Obj_BD_DAL.Obj_CNX = new SqlConnection(ConfigurationManager.ConnectionStrings["WIN_AUT"].ToString());


                if (Obj_BD_DAL.Obj_CNX.State == ConnectionState.Closed)
                {
                    Obj_BD_DAL.Obj_CNX.Open();
                }

                Obj_BD_DAL.Obj_CMD = new SqlCommand (Obj_BD_DAL.sNomSP, // nombre del store procedure que debe ejecutar en la BD
                                                     Obj_BD_DAL.Obj_CNX); // conexion a la BD previamente costruida y abierta.

                Obj_BD_DAL.Obj_CMD.CommandType = CommandType.StoredProcedure;

                #region AGREGAR PARÁMETROS

                    if (Obj_BD_DAL.DT_Parametros != null)
                    {
                        SqlDbType TipoDatoSQL = SqlDbType.VarChar;

                        foreach (DataRow dr in Obj_BD_DAL.DT_Parametros.Rows)
                        {
                            #region Definición de tipos de Datos del SQL

                                switch (dr[1])
                                {
                                    case "1":
                                        {
                                            TipoDatoSQL = SqlDbType.Int;
                                            break;
                                        }
                                    case "2":
                                        {
                                            TipoDatoSQL = SqlDbType.Decimal;
                                            break;
                                        }
                                    case "3":
                                        {
                                            TipoDatoSQL = SqlDbType.Float;
                                            break;
                                        }
                                    case "4":
                                        {
                                            TipoDatoSQL = SqlDbType.Char;
                                            break;
                                        }
                                    case "5":
                                        {
                                            TipoDatoSQL = SqlDbType.NChar;
                                            break;
                                        }
                                    case "6":
                                        {
                                            TipoDatoSQL = SqlDbType.VarChar;
                                            break;
                                        }
                                    case "7":
                                        {
                                            TipoDatoSQL = SqlDbType.NVarChar;
                                            break;
                                        }
                                    case "8":
                                        {
                                            TipoDatoSQL = SqlDbType.DateTime;
                                            break;
                                        }
                                    case "9":
                                        {
                                            TipoDatoSQL = SqlDbType.Bit;
                                            break;
                                        }
                                    case "10":
                                        {
                                            TipoDatoSQL = SqlDbType.Money;
                                            break;
                                        }

                                    default:
                                        break;
                                }

                            #endregion

                            Obj_BD_DAL.Obj_CMD.Parameters.Add(dr[0].ToString(), // nombre del parametro
                                                              TipoDatoSQL  // el tipo de datos que entiende el sql - resultado del switch
                                                              ).Value = dr[2].ToString(); // el valor del parametro

                        }
                    }

                #endregion

                
                if (Obj_BD_DAL.sIndAxn == "NORMAL")
                {                    
                    Obj_BD_DAL.Obj_CMD.ExecuteNonQuery();
                    Obj_BD_DAL.sValorScalar = string.Empty;
                }
                else
                {
                    Obj_BD_DAL.sValorScalar = Obj_BD_DAL.Obj_CMD.ExecuteScalar().ToString().Trim();                    
                }
                
                Obj_BD_DAL.sMsjErrorBD = string.Empty;
            }
            catch (SqlException ex)
            {
                Obj_BD_DAL.sMsjErrorBD = ex.Message.ToString();
            }
            finally
            {
                if (Obj_BD_DAL.Obj_CNX.State == ConnectionState.Open)
                {
                    Obj_BD_DAL.Obj_CNX.Close();
                }

                Obj_BD_DAL.Obj_CNX.Dispose();
            }
        }
    }
}
