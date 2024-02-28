namespace BL
{
    public class Hospital
    {
        public static Dictionary<string, object> GetAll()
        {
            ML.Hospital hospital = new ML.Hospital();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Hospital", hospital }, { "Excepcion", "" } };

            try
            {
                using(DL.RvazquezHospitalContext context = new DL.RvazquezHospitalContext())
                {
                    var registros = (from hos in context.Hospitals
                                     select new
                                     {
                                         IdHospital = hos.IdHospital,
                                         Nombre = hos.Nombre,
                                         Direccion = hos.Direccion,
                                         AñoConstruccion = hos.AñoConstruccion,
                                         Capacidad = hos.Capacidad,
                                     }).ToList();
                    if ( registros != null )
                    {
                        hospital.Hospitales = new List<object>();
                        foreach ( var registro in registros )
                        {
                            ML.Hospital hospitalObj = new ML.Hospital();
                            hospitalObj.IdHospital = registro.IdHospital;
                            hospitalObj.Nombre = registro.Nombre;
                            hospitalObj.Direccion = registro.Direccion;
                            hospitalObj.AñoConstruccion = registro.AñoConstruccion;
                            hospitalObj.Capacidad = registro.Capacidad;

                            hospital.Hospitales.Add( hospitalObj );
                        }

                        diccionario["Resultado"] = true;
                        diccionario["Hospital"] = hospital;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> Add(ML.Hospital hospital)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Excepcion", "" } };

            try
            {
                using (DL.RvazquezHospitalContext context = new DL.RvazquezHospitalContext())
                {

                }
            }
            catch (Exception ex)
            {
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> Delete(int idHospital)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Excepcion", "" } };

            try
            {
                using (DL.RvazquezHospitalContext context = new DL.RvazquezHospitalContext())
                {

                }
            }
            catch (Exception ex)
            {
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> Update(ML.Hospital hospital)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Excepcion", "" } };

            try
            {
                using (DL.RvazquezHospitalContext context = new DL.RvazquezHospitalContext())
                {

                }
            }
            catch (Exception ex)
            {
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> GetById(int idHospital)
        {
            ML.Hospital hospital = new ML.Hospital();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Hospital", hospital }, { "Excepcion", "" } };

            try
            {
                using (DL.RvazquezHospitalContext context = new DL.RvazquezHospitalContext())
                {

                }
            }
            catch (Exception ex)
            {
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
    }
}