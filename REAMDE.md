# 🧪 Cliente ejemplo C# con Firely

Carlos Jarero <carlos@cjarero.com>

Este proyecto usa el SDK de Firely para interactuar con servidores FHIR.

Tiene licencia BSD 3-Clause License

---

## 🔗 Recursos

* **Repositorio:** [irely-net-sdk](https://github.com/FirelyTeam/firely-net-sdk)
* **Documentación oficial:** [Firely .NET SDK Docs](https://docs.fire.ly/projects/Firely-NET-SDK/en/latest/)

---

## 📦 Paquete NuGet

Para usar en otro proyecto la librería es necesario ejecutar el siguiente comando:

```bash
dotnet add package Hl7.Fhir.R4 --version 6.0.0-alpha2
```

> ⚠️ Esto solo es un ejemplo.

---

## ▶️ Cómo ejecutar en VS Code

1. **Establece la variable de entorno del servidor FHIR** en tu terminal antes de abrir VS Code:

   ```bash
   export EXAMPLE_FHIR_SERVER="https://fhir.mi-servidor.com" # Investiga el equivalente en Windows
   code .
   ```

2. Abre el archivo `.vscode/launch.json` y asegúrate de **modificar los argumentos** para incluir el recurso FHIR que deseas consultar. Por ejemplo:

   ```json
   "args": [
     "Patient/22"
   ]
   ```

   > ⚠️ Asegúrate de reemplazar `"Patient/22"` por el recurso o endpoint que deseas probar.

3. Compila las dependencias del proyecto ejecutando:

   ```bash
   dotnet restore
   ```

4. Presiona `F5` en VS Code o selecciona **“Run > Start Debugging”**.

   Verás la salida del programa conectándose al servidor FHIR especificado.

---

