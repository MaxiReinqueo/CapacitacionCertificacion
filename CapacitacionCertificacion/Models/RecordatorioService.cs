using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacitacionCertificacion.Models
{
    public class RecordatorioService : BackgroundService
    {
        private RecordatorioAutomatico recordatorio = RecordatorioAutomatico.getInstancia;
        private readonly ILogger<RecordatorioService> _logger;

        public RecordatorioService(ILogger<RecordatorioService> logger)
        {
            _logger = logger;
            recordatorio.agregarRecordatorio("Tienes un curso sin terminar");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (recordatorio.isTimeParaEjecucion())
                {
                    _logger.LogInformation(recordatorio.imprimirRecordatorios());
                }
               
                await Task.Delay(20000, stoppingToken);
            }
        }
    }
}
