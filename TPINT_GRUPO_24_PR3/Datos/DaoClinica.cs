using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace Datos
{
    public class DaoClinica
    {
        AccesoDatos conexion = new AccesoDatos();


        //////////////////////// LOGIN /////////////////////////////
        public DataTable Login(string nombreUsuario, string contrasenia)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT *
                        FROM Usuario
                        WHERE NombreUsuario_USU = @NombreUsuario
                        AND Contraseña_USU = @Contraseña
                        AND Estado_USU = 1";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
            command.Parameters.AddWithValue("@Contraseña", contrasenia);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        /////////////////////////// PACIENTES /////////////////////////////////////

        public DataTable ListarPacientes(string busqueda, string sexo, int idProvincia)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT 
                            IdPaciente_PAC, 
                            DNI_PAC, 
                            Nombre_PAC, 
                            Apellido_PAC, 
                            Sexo_PAC, 
                            Nacionalidad_PAC,
                            FechaNacimiento_PAC, 
                            Direccion_PAC, 
                            Email_PAC, 
                            Telefono_PAC,
                            Nombre_LOC AS Localidad, 
                            Nombre_PRO AS Provincia
                            FROM Paciente
                            INNER JOIN Localidad 
                            ON Paciente.IdLocalidad_PAC = Localidad.IdLocalidad_LOC
                            INNER JOIN Provincia 
                            ON Localidad.IdProvincia_LOC = Provincia.IdProvincia_PRO
                            WHERE Paciente.Estado_PAC = 1
                            AND 
                            (@Busqueda = ''
                            OR DNI_PAC LIKE '%' + @Busqueda + '%'
                            OR Nombre_PAC LIKE '%' + @Busqueda + '%'
                            OR Apellido_PAC LIKE '%' + @Busqueda + '%')
                            AND 
                            (@Sexo = '' OR Sexo_PAC = @Sexo)
                            AND 
                            (@IdProvincia = 0 OR Provincia.IdProvincia_PRO = @IdProvincia)";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@Busqueda", busqueda);
            command.Parameters.AddWithValue("@Sexo", sexo);
            command.Parameters.AddWithValue("@IdProvincia", idProvincia);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            return dataTable;
        }


        public DataTable BuscarPaciente(string DNI)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = "SELECT IdPaciente_PAC, DNI_PAC, Nombre_PAC, Apellido_PAC, Sexo_PAC, Nacionalidad_PAC, " +
                              "FechaNacimiento_PAC, Direccion_PAC, Email_PAC, Telefono_PAC, Paciente.IdLocalidad_PAC, Provincia.IdProvincia_PRO, " +
                              "Nombre_LOC AS Localidad, Nombre_PRO AS Provincia " +
                              "FROM Paciente " +
                              "INNER JOIN Localidad ON Paciente.IdLocalidad_PAC = Localidad.IdLocalidad_LOC " +
                              "INNER JOIN Provincia ON Localidad.IdProvincia_LOC = Provincia.IdProvincia_PRO " +
                              "WHERE Paciente.Estado_PAC = 1 AND DNI_PAC = @DNI";

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@DNI", DNI);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            return dataTable;
        }


        public void BajaLogicaPaciente(int id)
        {
            string consulta = "UPDATE Paciente SET Estado_PAC = 0 WHERE IdPaciente_PAC = @id";

            SqlConnection connection = conexion.ObtenerConexion();
            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public bool ExistePaciente(string DNI) /// validacion que evita repetidos
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = "SELECT COUNT(*) FROM Paciente WHERE DNI_PAC = @DNI";

            SqlCommand cmd = new SqlCommand(consulta, connection);
            cmd.Parameters.AddWithValue("@DNI", DNI);

            connection.Open();

            int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

            connection.Close();

            if (cantidad > 0)
            {
                return true;
            }

            return false;
        }

        public int AgregarPaciente(Paciente paciente)
        {
            SqlConnection connection = conexion.ObtenerConexion();


            string consulta = @"INSERT INTO Paciente
                            (DNI_PAC, Nombre_PAC, Apellido_PAC, Sexo_PAC, Nacionalidad_PAC,
                            FechaNacimiento_PAC, Direccion_PAC, Email_PAC, Telefono_PAC,
                            IdLocalidad_PAC, Estado_PAC)
                            VALUES
                            (@DNI,@Nombre,@Apellido,@Sexo,@Nacionalidad,
                            @FechaNacimiento,@Direccion,@Email,@Telefono,
                            @IdLocalidad,1)";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@DNI", paciente.getDNI());
            command.Parameters.AddWithValue("@Nombre", paciente.getNombre());
            command.Parameters.AddWithValue("@Apellido", paciente.getApellido());
            command.Parameters.AddWithValue("@Sexo", paciente.getSexo());
            command.Parameters.AddWithValue("@Nacionalidad", paciente.getNacionalidad());
            command.Parameters.AddWithValue("@FechaNacimiento", paciente.getFechaNacimiento());
            command.Parameters.AddWithValue("@Direccion", paciente.getDireccion());
            command.Parameters.AddWithValue("@Email", paciente.getEmail());
            command.Parameters.AddWithValue("@Telefono", paciente.getTelefono());
            command.Parameters.AddWithValue("@IdLocalidad", paciente.getIdLocalidad());
            command.Parameters.AddWithValue("@Estado", paciente.getEstado());


            connection.Open();
            int filas = command.ExecuteNonQuery(); /// advierte filas afectadas
            connection.Close();
            return filas;
        }
        public int ModificarPaciente(Paciente paciente)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"UPDATE Paciente
                                SET IdLocalidad_PAC = @IdLocalidad,
                                    DNI_PAC = @DNI,
                                    Nombre_PAC = @Nombre,
                                    Apellido_PAC = @Apellido,
                                    Sexo_PAC = @Sexo,
                                    Nacionalidad_PAC = @Nacionalidad,
                                    FechaNacimiento_PAC = @FechaNacimiento,
                                    Direccion_PAC = @Direccion,
                                    Email_PAC = @Email,
                                    Telefono_PAC = @Telefono,
                                    Estado_PAC = @Estado
                                    WHERE IdPaciente_PAC = @IdPaciente";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@IdPaciente", paciente.getIdPaciente());
            command.Parameters.AddWithValue("@IdLocalidad", paciente.getIdLocalidad());
            command.Parameters.AddWithValue("@DNI", paciente.getDNI());
            command.Parameters.AddWithValue("@Nombre", paciente.getNombre());
            command.Parameters.AddWithValue("@Apellido", paciente.getApellido());
            command.Parameters.AddWithValue("@Sexo", paciente.getSexo());
            command.Parameters.AddWithValue("@Nacionalidad", paciente.getNacionalidad());
            command.Parameters.AddWithValue("@FechaNacimiento", paciente.getFechaNacimiento());
            command.Parameters.AddWithValue("@Direccion", paciente.getDireccion());
            command.Parameters.AddWithValue("@Email", paciente.getEmail());
            command.Parameters.AddWithValue("@Telefono", paciente.getTelefono());
            command.Parameters.AddWithValue("@Estado", paciente.getEstado());

            connection.Open();
            int filas = command.ExecuteNonQuery();
            connection.Close();

            return filas;
        }
        ///////////////////////// MEDICOS ////////////////////////////////////

        public DataTable ListarMedicos()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT
                                    Legajo_MED,
                                    DNI_MED,
                                    Nombre_MED,
                                    Apellido_MED,
                                    Descripcion_ESP,
                                    Nombre_LOC,
                                    Nombre_PRO,
                                    Sexo_MED,
                                    Nacionalidad_MED,
                                    FechaNacimiento_MED,
                                    Direccion_MED,
                                    Email_MED,
                                    Telefono_MED
                                FROM Medico
                                    INNER JOIN Especialidad
                                    ON Medico.IdEspecialidad_MED = Especialidad.IdEspecialidad_ESP
                                    INNER JOIN Localidad
                                    ON Medico.IdLocalidad_MED = Localidad.IdLocalidad_LOC
                                    INNER JOIN Provincia
                                    ON Localidad.IdProvincia_LOC = Provincia.IdProvincia_PRO
                                WHERE Medico.Estado_MED = 1";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, connection);

            dataAdapter.Fill(dataTable);

            return dataTable;
        }



        public DataTable ListarMedicosPorEspecialidad(int especialidad)
        {
            DataTable dataTable = new DataTable();
            string consulta = "SELECT Legajo_MED, Apellido_MED + ', ' + Nombre_MED AS NombreCompleto FROM Medico WHERE IdEspecialidad_MED = @especialidad ORDER BY Nombre_MED";

            SqlConnection connection = conexion.ObtenerConexion();

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@especialidad", especialidad);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable ListarMedicosPorLegajo(int legajo)
        {
            DataTable dataTable = new DataTable();
            string consulta = "SELECT Legajo_MED, " +
                                    " Apellido_MED, " +
                                    " Nombre_MED AS NombreCompleto " +
                                "FROM Medico " +
                               "WHERE Legajo_MED = @legajo " +
                               "ORDER BY Nombre_MED";

            SqlConnection connection = conexion.ObtenerConexion();

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@legajo", legajo);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            return dataTable;
        }




        public void BajaLogicaMedico(int legajo)
        {
            string consulta = @"UPDATE Medico SET Estado_MED = 0 WHERE Legajo_MED = @legajo; 
                                UPDATE Usuario SET Estado_USU = 0 WHERE IdUsuario_USU = 
                               (SELECT IdUsuario_MED FROM Medico WHERE Legajo_MED = @legajo);";

            SqlConnection connection = conexion.ObtenerConexion();
            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@legajo", legajo);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public int AgregarMedico(Medico medico)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"INSERT INTO Medico
                                (
                                    Nombre_MED,
                                    Apellido_MED,
                                    IdEspecialidad_MED,
                                    Estado_MED,
                                    DNI_MED,
                                    Sexo_MED,
                                    Nacionalidad_MED,
                                    FechaNacimiento_MED,
                                    Direccion_MED,
                                    Email_MED,
                                    Telefono_MED,
                                    IdLocalidad_MED
                                )
                                VALUES
                                (
                                    @Nombre,
                                    @Apellido,
                                    @Especialidad,
                                    1,
                                    @DNI,
                                    @Sexo,
                                    @Nacionalidad,
                                    @FechaNacimiento,
                                    @Direccion,
                                    @Email,
                                    @Telefono,
                                    @IdLocalidad
                                );

                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@Nombre", medico.getNombre());
            command.Parameters.AddWithValue("@Apellido", medico.getApellido());
            command.Parameters.AddWithValue("@Especialidad", medico.getIdEspecialidad());
            command.Parameters.AddWithValue("@DNI", medico.getDNI());
            command.Parameters.AddWithValue("@Sexo", medico.getSexo());
            command.Parameters.AddWithValue("@Nacionalidad", medico.getNacionalidad());
            command.Parameters.AddWithValue("@FechaNacimiento", medico.getFechaNacimiento());
            command.Parameters.AddWithValue("@Direccion", medico.getDireccion());
            command.Parameters.AddWithValue("@Email", medico.getEmail());
            command.Parameters.AddWithValue("@Telefono", medico.getTelefono());
            command.Parameters.AddWithValue("@IdLocalidad", medico.getIdLocalidad());

            connection.Open();
            int legajoGenerado = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return legajoGenerado;
        }
        ////////////////////////// HORARIO MEDICO ///////////////////////////////////////////////////
        public int AgregarHorarioMedico(int legajo, int diaSemana, TimeSpan horaInicio, TimeSpan horaFin)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"INSERT INTO HorarioMedico
                                (Legajo_HM, DiaSemana_HM, HoraInicio_HM, HoraFin_HM, Estado_HM)
                                VALUES (@Legajo, @DiaSemana, @HoraInicio, @HoraFin, 1)";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@Legajo", legajo);
            command.Parameters.AddWithValue("@DiaSemana", diaSemana);
            command.Parameters.AddWithValue("@HoraInicio", horaInicio);
            command.Parameters.AddWithValue("@HoraFin", horaFin);

            connection.Open();
            int filas = command.ExecuteNonQuery();
            connection.Close();

            return filas;
        }

        public int EliminarHorarioMedico(int idHorario)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = "DELETE FROM HorarioMedico WHERE IdHorario_HM = @IdHorario";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("IdHorario", idHorario);

            connection.Open();
            int filas = command.ExecuteNonQuery();
            connection.Close();

            return filas;
        }

        public DataTable ObtenerHorariosMedico(int legajo)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT IdHorario_HM, DiaSemana_HM,
                                CASE DiaSemana_HM
                                    WHEN 1 THEN 'Lunes'
                                    WHEN 2 THEN 'Martes'
                                    WHEN 3 THEN 'Miércoles'
                                    WHEN 4 THEN 'Jueves'
                                    WHEN 5 THEN 'Viernes'
                                END AS Dia,
                                HoraInicio_HM, HoraFin_HM
                                FROM HorarioMedico
                                WHERE Legajo_HM = @Legajo
                                ORDER BY DiaSemana_HM, HoraInicio_HM";

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@Legajo", legajo);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public bool ExisteMedico(string dni)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            string consulta = "SELECT COUNT(*) FROM Medico WHERE DNI_MED = @DNI";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@DNI", dni);

            cn.Open();
            int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();

            return cantidad > 0;
        }

        public DataTable ListarProvincias()
        {
            DataTable dataTable = new DataTable();
            string consulta = "SELECT IdProvincia_PRO, Nombre_PRO FROM Provincia ORDER BY Nombre_PRO";

            SqlConnection connection = conexion.ObtenerConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, connection);

            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable ListarLocalidadesPorProvincia(int idProvincia)
        {
            DataTable dataTable = new DataTable();
            string consulta = "SELECT IdLocalidad_LOC, Nombre_LOC FROM Localidad WHERE IdProvincia_LOC = @id ORDER BY Nombre_LOC";

            SqlConnection connection = conexion.ObtenerConexion();

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@id", idProvincia);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable ObtenerEspecialidades()
        {
            DataTable dataTable = new DataTable();
            string consulta = "SELECT IdEspecialidad_ESP, Descripcion_ESP FROM Especialidad ORDER BY Descripcion_ESP";

            SqlConnection connection = conexion.ObtenerConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, connection);

            dataAdapter.Fill(dataTable);

            return dataTable;
        }


        /////////////////////////////////// USUARIO /////////////////////////////////////////////////
        public int AgregarUsuario(Usuario usuario)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            string consulta = @"INSERT INTO Usuario
                                (
                                    NombreUsuario_USU,
                                    Contraseña_USU,
                                    Tipo_USU,
                                    Estado_USU
                                )
                                VALUES
                                (
                                    @NombreUsuario,
                                    @Contraseña,
                                    1,
                                    1
                                );

                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlCommand cmd = new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue("@NombreUsuario", usuario.getNombreUsuario());
            cmd.Parameters.AddWithValue("@Contraseña", usuario.getPassword());

            cn.Open();
            int idUsuario = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();

            return idUsuario;
        }

        public bool ExisteNombreUsuario(string nombreUsuario)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = "SELECT COUNT(*) FROM Usuario WHERE NombreUsuario_USU = @NombreUsuario";

            SqlCommand cmd = new SqlCommand(consulta, connection);
            cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

            connection.Open();
            int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            return cantidad > 0;
        }

        public string ObtenerNombreMedico(int idUsuario)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = "SELECT Nombre_MED + ' ' + Apellido_MED FROM Medico WHERE IdUsuario_MED = @IdUsuario";

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@IdUsuario", idUsuario);

            connection.Open();
            string nombreCompleto = command.ExecuteScalar().ToString();
            connection.Close();

            return nombreCompleto;
        }

        public DataTable ObtenerMedicosDDL()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT 
                                Legajo_MED,
                                CAST(Legajo_MED AS VARCHAR) + ' - ' + Apellido_MED + ', ' + Nombre_MED AS Medico
                                FROM Medico
                                WHERE Estado_MED = 1
                                ORDER BY Legajo_MED";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, connection);

            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public int ObtenerIdUsuarioMedico(int legajo)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = "SELECT IdUsuario_MED FROM Medico WHERE Legajo_MED = @Legajo";

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@Legajo", legajo);

            connection.Open();

            object resultado = command.ExecuteScalar();

            int idUsuario = 0;

            if (resultado != DBNull.Value)
            {
                idUsuario = Convert.ToInt32(resultado);
            }

            connection.Close();

            return idUsuario;
        }


        public int VincularUsuarioMedico(int legajo, int idUsuario)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = "UPDATE Medico SET IdUsuario_MED = @IdUsuario WHERE Legajo_MED = @Legajo";

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@IdUsuario", idUsuario);
            command.Parameters.AddWithValue("@Legajo", legajo);

            connection.Open();
            int filas = command.ExecuteNonQuery();
            connection.Close();

            return filas;
        }

        public DataTable ObtenerUsuarioPorId(int idUsuario)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT IdUsuario_USU,
                               NombreUsuario_USU,
                               Contraseña_USU
                               FROM Usuario
                               WHERE IdUsuario_USU = @IdUsuario";

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@IdUsuario", idUsuario);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public int ModificarUsuario(int idUsuario, Usuario usuario)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"UPDATE Usuario
                                SET NombreUsuario_USU = @NombreUsuario, Contraseña_USU = @Contraseña
                                WHERE IdUsuario_USU = @IdUsuario";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@IdUsuario", idUsuario);
            command.Parameters.AddWithValue("@NombreUsuario", usuario.getNombreUsuario());
            command.Parameters.AddWithValue("@Contraseña", usuario.getPassword());

            connection.Open();
            int filas = command.ExecuteNonQuery();
            connection.Close();

            return filas;
        }

        /////////////////////////// MEDICO //////////////////////////////////////////////////

        public DataTable BuscarMedico(string DNI)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT
                                    Legajo_MED,
                                    DNI_MED,
                                    Nombre_MED,
                                    Apellido_MED,
                                    Descripcion_ESP AS Especialidad,
                                    Nombre_LOC AS Localidad,
                                    Nombre_PRO AS Provincia,
                                    Sexo_MED,
                                    Nacionalidad_MED,
                                    FechaNacimiento_MED,
                                    Direccion_MED,
                                    Email_MED,
                                    Telefono_MED,
                                    IdEspecialidad_MED,
                                    IdLocalidad_MED,
                                    IdProvincia_PRO
                                FROM Medico
                                    INNER JOIN Especialidad
                                    ON Medico.IdEspecialidad_MED = Especialidad.IdEspecialidad_ESP
                                    INNER JOIN Localidad
                                    ON Medico.IdLocalidad_MED = Localidad.IdLocalidad_LOC
                                    INNER JOIN Provincia
                                    ON Localidad.IdProvincia_LOC = Provincia.IdProvincia_PRO
                                WHERE Medico.Estado_MED = 1
                                AND DNI_MED = @DNI";

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@DNI", DNI);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public int ModificarMedico(Medico medico)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"UPDATE Medico
                    SET IdEspecialidad_MED = @IdEspecialidad,
                        IdLocalidad_MED = @IdLocalidad,
                        DNI_MED = @DNI,
                        Nombre_MED = @Nombre,
                        Apellido_MED = @Apellido,
                        Sexo_MED = @Sexo,
                        Nacionalidad_MED = @Nacionalidad,
                        FechaNacimiento_MED = @FechaNacimiento,
                        Direccion_MED = @Direccion,
                        Email_MED = @Email,
                        Telefono_MED = @Telefono,
                        Estado_MED = @Estado
                    WHERE Legajo_MED = @Legajo";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@Legajo", medico.getLegajo());
            command.Parameters.AddWithValue("@IdEspecialidad", medico.getIdEspecialidad());
            command.Parameters.AddWithValue("@IdLocalidad", medico.getIdLocalidad());
            command.Parameters.AddWithValue("@DNI", medico.getDNI());
            command.Parameters.AddWithValue("@Nombre", medico.getNombre());
            command.Parameters.AddWithValue("@Apellido", medico.getApellido());
            command.Parameters.AddWithValue("@Sexo", medico.getSexo());
            command.Parameters.AddWithValue("@Nacionalidad", medico.getNacionalidad());
            command.Parameters.AddWithValue("@FechaNacimiento", medico.getFechaNacimiento());
            command.Parameters.AddWithValue("@Direccion", medico.getDireccion());
            command.Parameters.AddWithValue("@Email", medico.getEmail());
            command.Parameters.AddWithValue("@Telefono", medico.getTelefono());
            command.Parameters.AddWithValue("@Estado", medico.getEstado());

            connection.Open();
            int filas = command.ExecuteNonQuery();
            connection.Close();

            return filas;
        }



        //////////////////////////////////////// ASIGNACION DE TURNOS ////////////////////////////////////////
        public DataTable BuscarPacientePorDni(string DNI)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT
                        IdPaciente_PAC,
                        DNI_PAC,
                        Nombre_PAC,
                        Apellido_PAC,
                        Sexo_PAC,
                        Nacionalidad_PAC,
                        FechaNacimiento_PAC
                        FROM Paciente
                        WHERE DNI_PAC = @DNI";

            SqlCommand comando = new SqlCommand(consulta, connection);
            comando.Parameters.AddWithValue("@DNI", DNI);

            SqlDataAdapter adapter = new SqlDataAdapter(comando);

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);

            return tabla;

        }

        public bool AgregarTurno(int legajo, int idPaciente, DateTime fecha, TimeSpan hora)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"INSERT INTO Turno
                        (Fecha_TUR, Hora_TUR, IdPaciente_TUR, Legajo_TUR, Asistencia_TUR)
                        VALUES
                        (@Fecha, @Hora, @Paciente, @Medico, @Asistencia)";

            SqlCommand comando = new SqlCommand(consulta, connection);

            comando.Parameters.AddWithValue("@Fecha", fecha.Date);
            comando.Parameters.AddWithValue("@Hora", hora);
            comando.Parameters.AddWithValue("@Paciente", idPaciente);
            comando.Parameters.AddWithValue("@Medico", legajo);
            comando.Parameters.AddWithValue("@Asistencia", DBNull.Value);

            try
            {
                connection.Open();

                int filas = comando.ExecuteNonQuery();

                connection.Close();

                return filas > 0;
            }
            catch (Exception ex)
            {
                connection.Close();
                throw new Exception("Error al insertar turno: " + ex.Message);
            }
        }

        public List<TimeSpan> ObtenerHorariosOcupados(int legajo, DateTime fecha)
        {
            List<TimeSpan> ocupados = new List<TimeSpan>();

            SqlConnection cn = conexion.ObtenerConexion();

            string consulta = @"SELECT Hora_TUR
                        FROM Turno
                        WHERE Legajo_TUR=@Legajo
                        AND Fecha_TUR=@Fecha";

            SqlCommand cmd = new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue("@Legajo", legajo);
            cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ocupados.Add((TimeSpan)dr["Hora_TUR"]);
            }

            cn.Close();

            return ocupados;
        }
        public List<TimeSpan> ObtenerHorariosDisponibles(int legajo, DateTime fecha)
        {
            List<TimeSpan> horarios = new List<TimeSpan>();

            SqlConnection cn = conexion.ObtenerConexion();

            int diaSemana = (int)fecha.DayOfWeek;

            //// dia lunes 0 dia domingo 7 
            if (diaSemana == 0)
                diaSemana = 7;

            string consulta = @"SELECT HoraInicio_HM, HoraFin_HM
                        FROM HorarioMedico
                        WHERE Legajo_HM=@Legajo
                        AND DiaSemana_HM=@Dia
                        AND Estado_HM=1";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@Legajo", legajo);
            cmd.Parameters.AddWithValue("@Dia", diaSemana);

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                TimeSpan inicio = (TimeSpan)dr["HoraInicio_HM"];
                TimeSpan fin = (TimeSpan)dr["HoraFin_HM"];

                while (inicio < fin)
                {
                    horarios.Add(inicio);
                    inicio = inicio.Add(TimeSpan.FromHours(1)); // Turnos de 1 hora
                }
            }

            cn.Close();

            List<TimeSpan> ocupados = ObtenerHorariosOcupados(legajo, fecha);

            return horarios.Except(ocupados).ToList();
        }
        public bool MedicoAtiendeEseDia(int legajo, DateTime fecha)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            int diaSemana = (int)fecha.DayOfWeek;
            if (diaSemana == 0)
                diaSemana = 7; // Si tu BD usa 1=Lunes ... 7=Domingo

            string consulta = @"SELECT COUNT(*)
                        FROM HorarioMedico
                        WHERE Legajo_HM=@Legajo
                        AND DiaSemana_HM=@Dia
                        AND Estado_HM=1";

            SqlCommand cmd = new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue("@Legajo", legajo);
            cmd.Parameters.AddWithValue("@Dia", diaSemana);

            cn.Open();

            int cantidad = (int)cmd.ExecuteScalar();

            cn.Close();

            return cantidad > 0;
        }

        public DataTable BuscarTurnoPorDni(int dni)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            string consulta = @"SELECT
                        T.IdTurno_TUR,
                        T.Fecha_TUR,
                        T.Hora_TUR,
                        P.Nombre_PAC + ' ' + P.Apellido_PAC AS Paciente,
                        M.Nombre_MED + ' ' + M.Apellido_MED AS Medico,
                        E.Descripcion_ESP AS Especialidad
                        FROM Turno T
                        INNER JOIN Paciente P
                            ON T.IdPaciente_TUR = P.IdPaciente_PAC
                        INNER JOIN Medico M
                            ON T.Legajo_TUR = M.Legajo_MED
                        INNER JOIN Especialidad E
                            ON M.IdEspecialidad_MED = E.IdEspecialidad_ESP
                        WHERE P.DNI_PAC = @Dni";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@Dni", dni);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }

        public bool EliminarTurno(int idTurno)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            string consulta = "DELETE FROM Turno WHERE IdTurno_TUR=@Id";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@Id", idTurno);

            cn.Open();

            int filas = cmd.ExecuteNonQuery();

            cn.Close();

            return filas > 0;
        }

        //////////////////////////////////////// INFORMES ////////////////////////////////////////


        public DataTable InformeTurnosMedico(int legajo, DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT Medico.Legajo_MED AS Legajo,
                               Medico.Nombre_MED AS Nombre,
                               Medico.Apellido_MED AS Apellido,
                               COUNT(Turno.IdTurno_TUR) AS Turnos
                        FROM Medico
                        LEFT JOIN Turno
                          ON Medico.Legajo_MED = Turno.Legajo_TUR
                         AND Turno.Fecha_TUR BETWEEN @FechaDesde AND @FechaHasta";

            if (legajo != 0)
            {
                consulta += " WHERE Medico.Legajo_MED = @Legajo";
            }

            consulta += @" GROUP BY Medico.Legajo_MED,
                            Medico.Nombre_MED,
                            Medico.Apellido_MED
                   ORDER BY Medico.Legajo_MED";

            SqlCommand comando = new SqlCommand(consulta, connection);
            comando.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            comando.Parameters.AddWithValue("@FechaHasta", fechaHasta);

            if (legajo != 0)
            {
                comando.Parameters.AddWithValue("@Legajo", legajo);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);

            return tabla;
        }

        public DataTable InformeTurnosEspecialidad(int idEspecialidad, DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            string consulta = @"SELECT E.Descripcion_ESP AS Especialidad,
                               COUNT(T.IdTurno_TUR) AS Cantidad
                        FROM Turno T
                        INNER JOIN Medico M
                            ON T.Legajo_TUR = M.Legajo_MED
                        INNER JOIN Especialidad E
                            ON M.IdEspecialidad_MED = E.IdEspecialidad_ESP
                        WHERE T.Fecha_TUR BETWEEN @FechaDesde AND @FechaHasta";

            if (idEspecialidad != 0)
            {
                consulta += " AND M.IdEspecialidad_MED = @ID";
            }

            consulta += @" GROUP BY E.Descripcion_ESP
                   ORDER BY Cantidad DESC";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);

            if (idEspecialidad != 0)
            {
                cmd.Parameters.AddWithValue("@ID", idEspecialidad);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

            return tabla;
        }


        public DataTable ListarTurnos()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT Turno.IdTurno_TUR,
                                       Paciente.Nombre_PAC AS Nombre,
                                       Paciente.Apellido_PAC AS Apellido,
                                       Paciente.DNI_PAC AS DNI,
                                       Turno.Fecha_TUR AS Fecha,
                                       Turno.Hora_TUR AS Hora,
                                  CASE
                                  WHEN Turno.Asistencia_TUR = 1 THEN 'Presente'
                                  WHEN Turno.Asistencia_TUR = 0 THEN 'Ausente'
                                  ELSE 'Pendiente'
                                END AS Asistencia
                                  FROM Turno
                            INNER JOIN Paciente
                                    ON Turno.IdPaciente_TUR = Paciente.IdPaciente_PAC
                            INNER JOIN Medico
                                    ON Turno.Legajo_TUR = Medico.Legajo_MED
                              ORDER BY Turno.Fecha_TUR, Turno.Hora_TUR";

            SqlCommand command = new SqlCommand(consulta, connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable BuscarTurnos(int usuario, string busqueda)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT  Turno.IdTurno_TUR,
                                        Paciente.Nombre_PAC AS Nombre,
                                        Paciente.Apellido_PAC AS Apellido,
                                        Paciente.DNI_PAC AS DNI,
                                        Turno.Fecha_TUR AS Fecha,
                                        Turno.Hora_TUR AS Hora,
                                   CASE
                                   WHEN Turno.Asistencia_TUR = 1 THEN 'Presente'
                                   WHEN Turno.Asistencia_TUR = 0 THEN 'Ausente'
                                   ELSE 'Pendiente'
                                 END AS Asistencia
                                   FROM Turno
                             INNER JOIN Paciente
                                     ON Turno.IdPaciente_TUR = Paciente.IdPaciente_PAC
                             INNER JOIN Medico
                                     ON Turno.Legajo_TUR = Medico.Legajo_MED
                                  WHERE Medico.IdUsuario_MED = @usuario
                                  AND ( Paciente.Nombre_PAC LIKE '%' + @busqueda + '%'
                                     OR Paciente.Apellido_PAC LIKE '%' + @busqueda + '%'
                                     OR Paciente.DNI_PAC LIKE '%' + @busqueda + '%' )
                               ORDER BY Turno.Fecha_TUR, Turno.Hora_TUR";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@usuario", usuario);
            command.Parameters.AddWithValue("@busqueda", busqueda);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable ObtenerTurnosPendientes(int usuario)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT  Turno.IdTurno_TUR,
                                        Paciente.Nombre_PAC AS Nombre,
                                        Paciente.Apellido_PAC AS Apellido,
                                        Paciente.DNI_PAC AS DNI,
                                        Turno.Fecha_TUR AS Fecha,
                                        Turno.Hora_TUR AS Hora,
                                   CASE
                                   WHEN Turno.Asistencia_TUR = 1 THEN 'Presente'
                                   WHEN Turno.Asistencia_TUR = 0 THEN 'Ausente'
                                   ELSE 'Pendiente'
                                 END AS Asistencia
                                   FROM Turno
                             INNER JOIN Paciente
                                     ON Turno.IdPaciente_TUR = Paciente.IdPaciente_PAC
                             INNER JOIN Medico
                                     ON Turno.Legajo_TUR = Medico.Legajo_MED
                                  WHERE Medico.IdUsuario_MED = @usuario
                                    AND Turno.Asistencia_TUR IS NULL
                               ORDER BY Turno.Fecha_TUR, Turno.Hora_TUR";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@usuario", usuario);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable ObtenerTurnosAnteriores(int usuario)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT  Turno.IdTurno_TUR,
                                        Paciente.Nombre_PAC AS Nombre,
                                        Paciente.Apellido_PAC AS Apellido,
                                        Paciente.DNI_PAC AS DNI,
                                        Turno.Fecha_TUR AS Fecha,
                                        Turno.Hora_TUR AS Hora,
                                   CASE
                                        WHEN Turno.Asistencia_TUR = 1 THEN 'Presente'
                                        WHEN Turno.Asistencia_TUR = 0 THEN 'Ausente'
                                        ELSE 'Pendiente'
                                 END AS Asistencia
                                   FROM Turno
                             INNER JOIN Paciente
                                     ON Turno.IdPaciente_TUR = Paciente.IdPaciente_PAC
                             INNER JOIN Medico
                                     ON Turno.Legajo_TUR = Medico.Legajo_MED
                                  WHERE Medico.IdUsuario_MED = @usuario
                                    AND Turno.Asistencia_TUR IS NOT NULL
                               ORDER BY Turno.Fecha_TUR, Turno.Hora_TUR";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@usuario", usuario);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);

            return dataTable;
        }

        public bool ActualizarAsistencia(int idTurno, bool asistencia)
        {
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"UPDATE Turno
                                SET Asistencia_TUR = @Asistencia
                                WHERE IdTurno_TUR = @IdTurno";

            SqlCommand command = new SqlCommand(consulta, connection);

            command.Parameters.AddWithValue("@Asistencia", asistencia);
            command.Parameters.AddWithValue("@IdTurno", idTurno);

            try
            {
                connection.Open();

                int filas = command.ExecuteNonQuery();

                return filas > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable ObtenerInformeAsistencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = conexion.ObtenerConexion();

            string consulta = @"SELECT
                            Fecha_TUR,
                            Hora_TUR,
                            Nombre_PAC + ' ' + Apellido_PAC AS Paciente,
                            Nombre_MED + ' ' + Apellido_MED AS Medico,
                            CASE
                            WHEN Asistencia_TUR = 1 THEN 'Presente'
                            WHEN Asistencia_TUR = 0 THEN 'Ausente'
                            ELSE 'Pendiente'
                            END
                            AS Asistencia
                            FROM Turno
                            INNER JOIN Paciente
                            ON Turno.IdPaciente_TUR = Paciente.IdPaciente_PAC
                            INNER JOIN Medico 
                            ON Turno.Legajo_TUR = Medico.Legajo_MED
                            WHERE Fecha_TUR BETWEEN @FechaDesde AND @FechaHasta
                            ORDER BY Fecha_TUR, Hora_TUR";


            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@FechaHasta", fechaHasta);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
