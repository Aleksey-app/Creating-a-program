# Creating a program
***СПбГЭТУ «ЛЭТИ»
Факультет компьютерных технологий и информатики (ФКТИ) 2024***
>Написать программу,используя схему Эйткена, вычислить приближенное значение функции
```y =f (x)``` , заданной таблично при данном значении аргумента ```xТ```.

  **Схема Эйткена является методом интерполяции, который позволяет вычислить приближенное значение функции ```f(x)``` по её значениям в некоторых точках. Этот метод обычно используется для интерполяции в случае, когда значения функции известны только в конечном наборе точек.
Для того чтобы использовать схему Эйткена, необходимо иметь набор значений ```xi``` и соответствующих им значений ```yi=f(xi)```. После этого можно вычислить приближенное значение функции в некоторой точке ```xT```.**

Этапы использования схемы Эйткена обычно выглядят следующим образом:
1. Выбор шага интерполяции ```h```: Этот шаг должен быть небольшим, но достаточным, чтобы точки интерполяции были достаточно близкими друг к другу.
2. Построение таблицы разделённых разностей: Используя значения ```yi```​, строится таблица разделённых разностей, которая будет использоваться для интерполяции.
3. Интерполяция: Используя построенную таблицу разделённых разностей и заданную точку ```xT```, вычисляется приближенное значение функции ```f(xT)```.
   
**Заданные значения:**
У нас есть три известные точки: ```
(x0,y0)=(9.95,15.2368), (x1,y1)=(10.25,18.1109)```, и точка, в которой мы хотим вычислить значение функции, ```  xT=10.777xT​=10.777```.

1. Построение таблицы разделённых разностей:
        Мы создаём массивы x и y, содержащие значения аргументов и соответствующие им значения функции.
        Затем вычисляем разделённые разности первого порядка ``` (deltaY1)``` и второго порядка ```  (deltaSquareY)```.

2. Интерполяция с помощью схемы Эйткена:
        Вычисляем разность между ```xT``` и ближайшей известной точкой ```x0```.
        Используем формулу схемы Эйткена для интерполяции, чтобы вычислить приближенное значение функции ```f(xT​)```:
   
![изображение](https://github.com/Aleksey-app/Creating-a-program/assets/71906604/7de36d67-291d-4844-8afa-20c323619ca4)

Подставляем известные значения и вычисляем результат.
Вывод результата:
    Выводим приближенное значение функции ```f(xT​)``` для заданного значения ```xT```
>Написать программу, для вычисления приближенного значения функции ```y=f(x)``` по интерполя-
ционной формуле Ньютона для интерполяции **вперед** или **назад**.
