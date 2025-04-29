using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Progreso1_EstefaniHuertas.Models;

    public class DbHuertas_Hotel : DbContext
    {
        public DbHuertas_Hotel (DbContextOptions<DbHuertas_Hotel> options)
            : base(options)
        {
        }

        public DbSet<Progreso1_EstefaniHuertas.Models.Cliente> Cliente { get; set; } = default!;

public DbSet<Progreso1_EstefaniHuertas.Models.Reserva> Reserva { get; set; } = default!;

public DbSet<Progreso1_EstefaniHuertas.Models.PlanRecompensa> PlanRecompensa { get; set; } = default!;
    }
