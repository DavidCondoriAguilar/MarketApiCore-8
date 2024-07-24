# MarketPeru API

Bienvenido a MarketPeru API, una poderosa solución desarrollada en C# Core diseñada para gestionar las operaciones de un mercado en Perú. Esta API facilita la administración de categorías de productos, guías de transporte, locales, órdenes de compra, productos y proveedores.

## Tabla de Contenidos
- [Instalación](#instalación)
- [Uso](#uso)
- [Estructura de la Base de Datos](#estructura-de-la-base-de-datos)
- [Endpoints](#endpoints)
- [Contribuir](#contribuir)
- [Licencia](#licencia)
- [Arquitectura](#arquitectura)

## Instalación
Sigue estos pasos para instalar y ejecutar MarketPeru API en tu entorno local:

1. Clona el repositorio
    ```sh
    git clone https://github.com/tu-usuario/MarketPeru.git
    ```

2. Navega al directorio del proyecto
    ```sh
    cd MarketPeru
    ```

3. Restaura los paquetes de NuGet
    ```sh
    dotnet restore
    ```

4. Configura la base de datos
    - Asegúrate de tener una instancia de SQL Server corriendo.
    - Actualiza el archivo `appsettings.json` con tu cadena de conexión.

5. Aplica las migraciones a la base de datos
    ```sh
    dotnet ef database update
    ```

6. Compila y ejecuta la aplicación
    ```sh
    dotnet run
    ```

## Arquitectura
MarketPeru API utiliza una **Arquitectura en Capas (Layered Architecture)**, también conocida como **Arquitectura Limpia (Clean Architecture)**. Esta arquitectura organiza el código en diferentes capas, cada una con responsabilidades específicas, promoviendo la separación de preocupaciones, el desacoplamiento y la facilidad de mantenimiento.

### Capas de la Arquitectura
1. **Capa de Presentación (Presentation Layer)**:
   - Maneja la interacción con el usuario a través de controladores y vistas.

2. **Capa de Aplicación (Application Layer)**:
   - Coordina las operaciones entre la capa de presentación y la capa de dominio.
   - Contiene la lógica de aplicación y los servicios.

3. **Capa de Dominio (Domain Layer)**:
   - Contiene la lógica de negocio y las reglas fundamentales de la aplicación.
   - Define las entidades y los servicios de dominio.

4. **Capa de Infraestructura (Infrastructure Layer)**:
   - Maneja la comunicación con sistemas externos, como bases de datos y servicios web.
   - Implementa repositorios y unidades de trabajo para el acceso a datos.

### Beneficios de la Arquitectura
- **Separación de Preocupaciones**: Cada capa tiene una responsabilidad específica, lo que facilita la comprensión y el mantenimiento del código.
- **Desacoplamiento**: Las capas están desacopladas entre sí, permitiendo modificar una capa sin afectar a las demás.
- **Testabilidad**: Las capas bien definidas facilitan la creación de pruebas unitarias y de integración.
- **Escalabilidad**: La estructura modular permite escalar la aplicación de manera más sencilla.

![22](https://github.com/DavidCondoriAguilar/MarketApiCore-8/assets/103283145/549c2c8b-a2f2-4fd5-9167-431567b0a1e9)
![3](https://github.com/DavidCondoriAguilar/MarketApiCore-8/assets/103283145/2eefe971-0a1e-421c-affc-74613f941b56)
![2](https://github.com/DavidCondoriAguilar/MarketApiCore-8/assets/103283145/6baca432-d1be-4fa5-a110-06a02919279d)
![1](https://github.com/DavidCondoriAguilar/MarketApiCore-8/assets/103283145/15a6f58d-7e6d-4026-bf63-e7a9e1c9aa52)
![4](https://github.com/DavidCondoriAguilar/MarketApiCore-8/assets/103283145/38b44c53-9b95-4248-a954-0338e574b035)







