
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace org.example;

public class FhirClientExample
{
    private static readonly ILogger _logger;

    private static readonly string fhirStringServer;

    private static readonly JsonSerializerOptions options = new JsonSerializerOptions().ForFhir(ModelInfo.ModelInspector).Pretty();

    static FhirClientExample()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        _logger = loggerFactory.CreateLogger<FhirClientExample>();
        fhirStringServer = Environment.GetEnvironmentVariable("EXAMPLE_FHIR_SERVER");
    }


    public static async System.Threading.Tasks.Task Main(string[] args)
    {
        Uri clientUrl;
        if (args.Length < 1 || string.IsNullOrWhiteSpace(args[0]))
        {
            _logger.LogError("No se especificó correctamente el parámetro del id aconsultar");
            Environment.Exit(1);
        }
        if (fhirStringServer == null || string.IsNullOrWhiteSpace(fhirStringServer))
        {
            _logger.LogError("No se especificó correctamente el servidor a consultar");
            Environment.Exit(1);
        }

        try
        {
            clientUrl = new Uri(fhirStringServer);
            string id = args[0].Trim();

            FhirClientSettings settings = new FhirClientSettings
            {
                Timeout = 60 * 1000, // Milisegundos
                PreferredFormat = ResourceFormat.Json,
                VerifyFhirVersion = true

            };

            FhirClient client = new FhirClient(clientUrl, settings);

            // Operación de lectura
            Resource resource = await client.ReadAsync<Resource>("Patient/22");

            if (resource is Patient)
            {
                Patient patient = (Patient) resource;
                _logger.LogInformation("Se encontró un paciente");
                _logger.LogInformation(JsonSerializer.Serialize(patient, options));
                Environment.Exit(0);
            }

            if (resource is Observation)
            {
                Observation observation = (Observation) resource;
                _logger.LogInformation("Se encontró una observación");
                _logger.LogInformation(JsonSerializer.Serialize(observation, options));
                Environment.Exit(0);
            }

            _logger.LogInformation($"Se encontró un recurso con id: {resource.Id} y tipo {resource.TypeName}");

        }
        catch (Exception e) when (e is ArgumentNullException || e is UriFormatException)
        {
            _logger.LogError(e.Message, e);
        }
    }
}
