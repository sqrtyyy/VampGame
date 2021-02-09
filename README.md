# Drakulam

## СОСТАВ КОМАНДЫ:
1. Герасименко Виктор — тим-лид
2. Антонов Алексей — тех-лид
3. Аникин Александр
4. Смирнова Дарья
5. Шагвалиев Михаил

# Требования к комментарию коммита:
1. На английском
2. С большой буквы
3. Глаголы пишутся в начальной форме (fix, add, change)
4. В комментарии пишется то, что было сделано, а не как
5. В комментарии должен быть указан номер issue (#123)

# Стандарт кодирования
## Имена методов, переменных, классов  
**Делать**
  1) Использовать в именах методов и переменных не более 3-х слов.
  2) Использовать ***PascalCasing*** для имен методов и классов.    
  3) Использовать ***camelCasing***. для имен переменных и аргументов методов.
  4) Использовать неявный тип var для объявлений локальных переменных. Исключение: примитивные типы(int, string, double, bool, etc)
  5) Использовать существительные для имен классов.
  6) Начинать имя интерфейса с буквы **I**. Имена интерфейсов состоят из существительного или прилагательного.
  
**Не делать**
  1) Писать капсом константы.
  2) Использовать **венгерскую** нотацию или нечто подобное.
  3) Пользвоваться аббревиатурами(user-usr, group-grp и так далее)

## Организация кода
**Делать**
  1) Выделять все namespace в отдельный блок.
  ```csharp
    // Examples
    namespace Company.Product.Module.SubModule;
    namespace Product.Module.Component;
    namespace Product.Layer.Module.Group;
  ```
  2) Объявлять все члены класса наверху класса. Прежде всего *static*
  ```csharp
  // Correct
public class Account {
    public static string BankName;
    public static decimal Reserves;
 
    public string Number {get; set;}
    public DateTime DateOpened {get; set;}
    public DateTime DateClosed {get; set;}
    public decimal Balance {get; set;}
    // Constructor
    public Account() {
        // ...
    }
}
  ```
  3) Переносить на новую строку, если длина текущей строки более 80 символов
  4) Разделять параметры метода пробелом.  
  5) Разделять все лексемы пробелом.
  
**Не делать**
  1) Переносить фигурную скобку на новую строку.


