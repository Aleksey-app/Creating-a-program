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
(x0,y0)=(9.95,15.2368), (x1,y1)=(10.25,18.1109)```, и точка, в которой мы хотим вычислить значение функции, ```  xT=10.777```.

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
>Написать программу, для вычисления приближенного значения функции ```y=f(x)``` по интерполяционной формуле Ньютона для интерполяции **вперед** или **назад**.

Для вычисления приближенного значения функции ```f(x)``` по интерполяционной формуле Ньютона для интерполяции вперёд или назад нам понадобится набор известных точек и значения функции в них.

Интерполяционная формула Ньютона для интерполяции вперёд:

![Вперед](https://github.com/Aleksey-app/Creating-a-program/assets/71906604/52368882-1fae-4f8b-abc5-5eeb00183c6f)

Интерполяционная формула Ньютона для интерполяции назад:

![назад](https://github.com/Aleksey-app/Creating-a-program/assets/71906604/e4320140-d682-4365-bc77-82b4122c80d7)

где ![где](https://github.com/Aleksey-app/Creating-a-program/assets/71906604/a183c94a-b514-4e9d-b15c-be5b3aad46cf) разделенная разность i-го порядка, вычисленная в точке xj.

**Заданные значения:**

У нас есть следующие данные: ```xT​=1.237
(x0,y0)=(1.25,13.4776)
(x1,y1)=(1.26,13.8759)
(x2,y2)=(1.27,14.2367)```

Теперь давайте используем интерполяционную формулу Ньютона для интерполяции вперёд, чтобы вычислить приближенное значение функции f(x) при xT=1.237.

Сначала мы вычислим разделенные разности:

![Раздельные разности](https://github.com/Aleksey-app/Creating-a-program/assets/71906604/ccbd3e0d-5e4a-4824-9e7c-68d4ea82684a)

Теперь, используя эти разделенные разности, мы можем вычислить приближенное значение функции ```f(xT​)``` по формуле Ньютона для интерполяции вперёд:

![для интерполяции вперед](https://github.com/Aleksey-app/Creating-a-program/assets/71906604/4851a240-6b5d-43ab-86a8-1442ddc56d42)

Вычислим каждое слагаемое:

![каждое слогаемое](https://github.com/Aleksey-app/Creating-a-program/assets/71906604/29dd0a7a-7d4b-467a-bac4-dfc2f4d1fd2c)

>Методом простых итераций с точностью ```e=10(-7)``` решить систему линейных алгебраических уравнений, заданную в форме ```A*x=b``` :



>Найти приближенное решение однородного уровнения гиперболического
![Задание 4](https://github.com/Aleksey-app/Creating-a-program/assets/71906604/5dd8deb9-259e-496a-939e-8e0097efe72d)

