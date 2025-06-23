using System;
using System.Collections.Generic;
using System.Linq;

// Estructura para representar a un paciente
public struct Paciente
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Identificacion { get; set; }
    public string Telefono { get; set; }
}

// Estructura para representar un turno
public struct Turno
{
    public DateTime FechaHora { get; set; }
    public string Medico { get; set; }
    public string Especialidad { get; set; }
    public Paciente Paciente { get; set; }
}

// Clase para gestionar la agenda de turnos
public class Agenda
{
    private List<Turno> turnos;

    public Agenda()
    {
        turnos = new List<Turno>();
    }

    // Métodos CRUD (Crear, Leer, Actualizar, Eliminar)
    public void AgregarTurno(Turno turno)
    {
        turnos.Add(turno);
    }

    public bool EliminarTurno(DateTime fechaHora)
    {
        // Elimina el primer turno que coincida con la fecha y hora
        return turnos.RemoveAll(t => t.FechaHora == fechaHora) > 0;
    }

    public Turno? BuscarTurno(DateTime fechaHora)
    {
        return turnos.FirstOrDefault(t => t.FechaHora == fechaHora);
    }

    public List<Turno> ListarTurnos()
    {
        return turnos;
    }

    // Reportería (visualización y consulta)
    public void MostrarTurnos()
    {
        if (turnos.Count == 0)
        {
            Console.WriteLine("No hay turnos agendados.");
            return;
        }

        Console.WriteLine("--- Lista de Turnos ---");
        foreach (var turno in turnos)
        {
            Console.WriteLine($"Fecha y Hora: {turno.FechaHora}, Médico: {turno.Medico}, Especialidad: {turno.Especialidad}, Paciente: {turno.Paciente.Nombre} {turno.Paciente.Apellido}");
        }
        Console.WriteLine("-----------------------");
    }

    public List<Turno> BuscarTurnosPorMedico(string medico)
    {
        return turnos.Where(t => t.Medico.ToLower().Contains(medico.ToLower())).ToList();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Agenda agenda = new Agenda();

        // Crear algunos pacientes
        Paciente paciente1 = new Paciente { Nombre = "Juan", Apellido = "Pérez", Identificacion = "1758469782", Telefono = "0995487125" };
        Paciente paciente2 = new Paciente { Nombre = "María", Apellido = "Gómez", Identificacion = "1745002510", Telefono = "0985217475" };
        Paciente paciente3 = new Paciente { Nombre = "Carlos", Apellido = "Rodríguez", Identificacion = "0604871171", Telefono = "0958755645" };
        Paciente paciente4 = new Paciente { Nombre = "Laura", Apellido = "Martínez", Identificacion = "1715174544", Telefono = "0968585966" };
        Paciente paciente5 = new Paciente { Nombre = "Pedro", Apellido = "Sánchez", Identificacion = "1822149900", Telefono = "0973654256" };

        // Crear y agregar 5 turnos de ejemplo
        agenda.AgregarTurno(new Turno { FechaHora = DateTime.Now.AddDays(1), Medico = "Dra. Ana Gómez", Especialidad = "Cardiología", Paciente = paciente1 });
        agenda.AgregarTurno(new Turno { FechaHora = DateTime.Now.AddDays(2), Medico = "Dr. Juan Pérez", Especialidad = "Medicina General", Paciente = paciente2 });
        agenda.AgregarTurno(new Turno { FechaHora = DateTime.Now.AddDays(3), Medico = "Dra. Sofía López", Especialidad = "Dermatología", Paciente = paciente3 });
        agenda.AgregarTurno(new Turno { FechaHora = DateTime.Now.AddDays(4), Medico = "Dr. Carlos Ramírez", Especialidad = "Traumatología", Paciente = paciente4 });
        agenda.AgregarTurno(new Turno { FechaHora = DateTime.Now.AddDays(5), Medico = "Dra. Elena Torres", Especialidad = "Pediatría", Paciente = paciente5 });

        agenda.MostrarTurnos();

        Console.ReadKey();
    }
}