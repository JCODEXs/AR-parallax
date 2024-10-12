# AR-parallax
Demo Unity app


# Integrar Vuforia en Unity: Creación de una Aplicación de Realidad Aumentada

Vuforia es una plataforma de realidad aumentada (AR) que permite superponer contenido digital sobre el mundo real, utilizando imágenes de referencia conocidas como "marcadores". A continuación, te explico los pasos para agregar una clave de licencia de Vuforia e iniciar una aplicación AR en Unity.

## Pasos para agregar una llave de licencia de Vuforia

### 1. Crear una cuenta en Vuforia Developer Portal
- Ve a [Vuforia Developer Portal](https://developer.vuforia.com/) y regístrate o inicia sesión.
- Crea un nuevo proyecto y genera una **licencia** para tu aplicación de AR. Esta clave es necesaria para que tu app funcione correctamente.

### 2. Subir imágenes como marcadores (Targets)
- Navega a la sección de **Target Manager** en el portal de Vuforia y crea una base de datos.
- Sube las imágenes que utilizarás como marcadores en tu aplicación.
- Vuforia analizará las imágenes y te indicará qué tan óptimas son para AR.
- Descarga la base de datos en formato Unity o Vuforia.

### 3. Configurar Unity con Vuforia
- Abre Unity y crea un nuevo proyecto 3D.
- Desde el **Package Manager**, instala el **Vuforia Engine**. Si no lo encuentras, puedes importarlo manualmente desde [Vuforia para Unity](https://developer.vuforia.com/downloads/sdk).
- Activa **Vuforia** en los **Player Settings** de Unity.
- Agrega la clave de licencia generada en el portal de Vuforia. Esto se realiza en la sección "Vuforia Configuration" del Inspector al seleccionar el objeto **ARCamera** en la escena.

### 4. Configurar los targets de imagen
- En Unity, arrastra el objeto **ARCamera** a tu escena (disponible en los prefabs de Vuforia).
- Agrega un componente **Image Target** a la escena.
- En la configuración de **Image Target**, selecciona la base de datos que descargaste de Vuforia y elige la imagen que será reconocida como marcador.

### 5. Desplegar contenido 3D sobre la imagen
- Después de configurar el **Image Target**, arrastra un objeto 3D (por ejemplo, un modelo o texto) como hijo del Image Target.
- Cuando Vuforia reconozca la imagen en tiempo real, el contenido 3D se mostrará sobre la imagen escaneada.

---

Al finalizar estos pasos, habrás creado una aplicación básica de realidad aumentada en Unity que utiliza Vuforia. La app reconocerá la imagen configurada y desplegará un objeto tridimensional sobre la imagen cuando sea detectada.
```

Este formato te permite tener una guía clara y organizada para seguir los pasos en Unity y Vuforia.
