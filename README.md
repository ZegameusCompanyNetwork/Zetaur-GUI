## Bienvanido a la Página Oficial de Zetaur-GUI

Esta aplicación permite al usuario tener una mejor experiencia de uso, cambiando la [CLI](https://es.wikipedia.org/wiki/Interfaz_de_l%C3%ADnea_de_comandos) por una [GUI](https://es.wikipedia.org/wiki/Interfaz_gr%C3%A1fica_de_usuario).
Por el momento la aplicación está compuesta por un Reloj Digital con Fecha y el Transformador de unidades.

### Reloj Digital

Este reloj tan sencillo usa el siguiente código en el Main Window:

```C#
public MainWindow()
{
  hora_lb.Content = DateTime.Now.ToLongTimeString(); //establecemos que se ha de mostrar en el cuadro de texto de la hora
  DispatcherTimer dispatcherTimer = new DispatcherTimer(); //Iniciamos el DispatcherTimer
  dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick); //Creamos el evento de actualización por tick
  dispatcherTimer.Interval = new TimeSpan(0, 0, 1);//Establecemos el intervalo de actualización a un segundo
  dispatcherTimer.Start();//Iniciamos el Reloj
  DateTime dt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
  string dtStr = dt.ToString(@"dd/MM/yyyy"); //Establecemos el texto de la fecha con un formato
  fecha_lb.Content = dtStr; //Mostramos el texto en la label
}
```
Y esta es el método dispatcherTimer_Tick
```C#
private void dispatcherTimer_Tick(object sender, EventArgs e)
{
  hora_lb.Content = DateTime.Now.ToLongTimeString();
}
```
Más información sobre [DispatcherTimer](https://docs.microsoft.com/es-es/dotnet/api/system.windows.threading.dispatchertimer?view=netcore-3.1).

### Conversor de unidades

El conversor de unidades es más complejo de lo que en un principio fue en la aplicación inicial, y más teniendo en cuenta que nunca antes había realizado una interfáz gráfica en [WPF](https://es.wikipedia.org/wiki/Windows_Presentation_Foundation). 

Actualmente el conversor funciona para las magnitudes Temperatura, Longitud, Masa y Presión; pero tengo pensado ampliarlo. 

Las unidades de Temperatura son: 
- Grados Celsisus (ºC)
- Grados Farenheit (ºF)
- Grados Kelvin (K)

Las unidades de longitud son:
1. Solo Múltiplos y Submúltiplos:
- Kilómetros
- Metros
- Centímetros
- Milímetros
- Micras (Micrómetros)
- Nanómetros
2. Sin Múltiplos ni Submúltiplos
- Kilómetros
- Metros
- Millas
- Millas Naúticas
- Pulgadas
- Yardas
- Pies

Las unidades de Masa y Presión se añadirán en la verisón 1.0.2.0


### Necesitas Ayuda?

Si has recibido algún error usando la aplicación usa este [Link](https://github.com/ZegameusCompanyNetwork/Zetaur-GUI/issues/new?assignees=&labels=bug&template=reportar-bug.md&title=%5BBUG%5D-), si quieres pedir algo nuevo usa este otro [Link](https://github.com/ZegameusCompanyNetwork/Zetaur-GUI/issues/new?assignees=&labels=documentation%2C+enhancement&template=solicitud-de-funciones.md&title=%5BExtras%5D+-+)
