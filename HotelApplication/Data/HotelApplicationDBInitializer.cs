using System;
using System.Diagnostics;
using System.Linq;
using HotelApplication.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelApplication.Data
{
    public class HotelApplicationDBInitializer
    {
        private readonly HotelApplicationDB _db;
        private readonly ILogger<HotelApplicationDBInitializer> _logger;

        public HotelApplicationDBInitializer(HotelApplicationDB db, ILogger<HotelApplicationDBInitializer> logger)
        {
            _db = db;
            _logger = logger;
        }
        public void Initialize()
        {
            _logger.LogInformation("Инициализация БД...");
            var timer = Stopwatch.StartNew();

            //_db.Database.EnsureDeleted();
            //_db.Database.EnsureCreated();

            if (_db.Database.GetPendingMigrations().Any())
            {
                _logger.LogInformation("Миграция БД...");
                _db.Database.Migrate();
                _logger.LogInformation("Миграция БД выполнена за {0}c", timer.Elapsed.TotalSeconds);
            }
            else
                _logger.LogInformation("Миграция БД не требуется. {0}c", timer.Elapsed.TotalSeconds);

            try
            {
                InitializeOrders();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ошибка при инициализации товаров в БД");
                throw;
            }

            _logger.LogInformation("Инициализация БД завершена за {0} с", timer.Elapsed.TotalSeconds);

            }
        private void InitializeOrders()
        {
            if (_db.Checkins.Any())
            {
                _logger.LogInformation("БД не нуждается в инициализации заказов");
                return;
            }

            _logger.LogInformation("Инициализация секций...");
            var timer = Stopwatch.StartNew();


            using (_db.Database.BeginTransaction())
            {
                _db.Clients.AddRange(TestData.Clients);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Clients] ON"); // Костыль!!!
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Clients] OFF");

                _db.Database.CommitTransaction();
            }

            _logger.LogInformation("Инициализация секций выполнена. {0} c", timer.Elapsed.TotalSeconds);

            _logger.LogInformation("Инициализация брендов...");

            using (_db.Database.BeginTransaction())
            {
                _db.Rooms.AddRange(TestData.Rooms);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Rooms] ON"); // Костыль!!!
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Rooms] OFF");

                _db.Database.CommitTransaction();
            }

            _logger.LogInformation("Инициализация брендов выполнена за. {0} c", timer.Elapsed.TotalSeconds);

            _logger.LogInformation("Инициализация товаров...");

            using (_db.Database.BeginTransaction())
            {
                _db.Checkins.AddRange(TestData.Checkins);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Checkins] ON"); // Костыль!!!
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Checkins] OFF");

                _db.Database.CommitTransaction();
            }
            _logger.LogInformation("Инициализация заказов выполнена за. {0} c", timer.Elapsed.TotalSeconds);
        }
    }
}
