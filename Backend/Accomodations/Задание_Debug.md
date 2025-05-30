# Консольное приложение для работы с бронями

### Возможности приложения:

#### Добавить бронь

- Параметры для совершения бронирования:
  - ИД пользователя (заказчика)
  - Категория номера
  - Название категории
  - Дата заезда
  - Дата выезда
  - Валюта бронирования

#### Отменить бронирование

- Параметры для отмены бронирования:
  - ИД бронирования

#### Поиск бронирования

- Параметры для поиска бронирования:
  - ИД бронирования

#### Поиск бронирования по фильтрам

- Параметры для поиска бронирования:
  - Дата заезда
  - Дата выезда
  - Название категории

#### Расчет штрафа за отмену брони

- Параметры для расчета штрафа:
  - Бронь

### Примеры команд и сценариев:

#### Начнем с пользовательского ввода

`book 1 Standard 3/30/2024 4/1/2024 rub`

##### Здесь нужно обратить внимание на несколько моментов:

1. Попробуйте ввести невалидную дату, например:
   `book 1 Standard 3/32/2024 4/1/2024 rub`.
   Программа упадет с ошибкой. Предложите свой вариант исправления данной ситуации, чтобы программа продолжала свою
   работу.
2. Прямо противоположная ситуация с вводом валюты. В случае, если будет введена неверная валюта, должен быть выброшен
   ArgumentException, согласно
   [документации](https://learn.microsoft.com/en-us/dotnet/api/system.enum.parse?view=net-8.0).
   Однако, приложение продолжает работу, обрабатывая данную ошибку. Поставьте точку останова на 51 строке
   файла `AccommodationsProcessor.cs` и пройдите отладчиком путь от начала вызова `Enum.Parse` до выбрасывания
   исключения.

   ![image](https://github.com/pklgn/dotnet-lectures/assets/73781985/30538450-8490-4913-bc6e-9ae45c51784a)

   Предложите вариант, как можно кастомизировать вывод ошибки парсинга (подсказка: ознакомьтесь
   с [докой](https://learn.microsoft.com/en-us/dotnet/api/system.enum.tryparse?view=net-8.0))

3. Проверьте возможность отмены команд для каждой команды и отмену команд, когда история команд пуста. При
   необходимости, внесите необходимые изменения в код, чтобы избежать выбрасывания исключений и аварийного завершения
   программы.

#### Перейдем непосредственно к бизнес-логике

Вам предложено несколько сценариев, о некорректном выполнении которых сообщили пользователи:

1. Попробуйте создать бронь на завтрашний (относительно момента выполнения кода) день.
   После этого отмените бронь.
   Приложение аварийно завершит свою работу, необходимо правильно обработать данную ситуацию, чтобы приложение
   продолжало выполнение.
2. Проверьте величину штрафа при корректной отмене брони. Введите необходимые команды в консоли и пройдите отладчиком
   путь расчета штрафа за отмену брони.
3. Поиск брони командой `find` содержит странный вывод: Не выводится название категории для найденной категории. Нужно
   выводить название категории

   ![image](https://github.com/pklgn/dotnet-lectures/assets/73781985/8117a61f-c3dd-4f02-ad3b-ac1d7ec5c01f)

4. Известно о неправильной стоимости при использовании валюты
   Пользователь ввел следующие данные:

- тариф **Standard** с базовой стоимостью **100** рублей
- количество дней бронирования: **1 день**
- валюта: **Юань**

На момент создания брони, обменный курс составлял 12.6487094041262 рублей за 1 юань.
Стоимость брони почему-то получилась отрицательная (-26.48709404126200) юаней.
Необходимо воспроизвести расчет стоимости брони с такими же данными.
Но как быть, если обменный курс непостоянный и диктуется нам ЦБ? (в коде просто генерируется случайное число в заданном
диапазоне). Для точного воспроизведения воспользуйтесь
[функциональностью](https://learn.microsoft.com/en-us/visualstudio/debugger/autos-and-locals-windows?view=vs-2022)
по изменению значений переменных текущего контекста. Поставьте точку останова внутри метода `CalculateBookingCost`
и пройдите с помощью шага с обходом/заходом все шаги алгоритма расчета. Внесите необходимые изменения для корректного
расчета стоимости при использовании валюты

### Задание и оценивание

Для выполнения задания нужно исправить все указанные ошибки. Также в программе присутствует еще несколько багов, которые
можно попробовать найти. Баги есть как в бизнес-логике, так и на уровне обработки пользовательских команд. Предлагаем
найти минимум по **еще 1 проблеме** на каждом из упомянутых слоев приложения (бизнес-логика и пользовательский ввод).
Найденные ошибки могут быть любыми, уровень их сложности не имеет значения, каждая найденная ошибка засчитывается.

Также создайте несколько бронирований и затем выполните их поиск с фильтром. Создайте брони с разными датами и
доступными категориями и отфильтруйте брони как по дате, так и по категории. Опишите в текстовом файлике процесс
фильтрации: укажите, какие брони оставались на каждом шаге. Для этого воспользуйтесь окном `Immediate Window` в Visual
Studio и высчитывайте результат запроса с помощью `query.ToList()`. Задокументировать можно в виде скриншотов, например, в
гугл доке и тогда в текстовый файлик необходимо добавить ссылку на док.

Скопируйте проект к себе и комментариями в коде отмечайте каждое исправление. Для более быстрого оценивания зафиксируйте
все исправления в текстовый файл и укажите имя файла и номер строки, где исправление было сделано. Файлик следует закоммитить
и положить в корень проекта. Название файла `fixes.txt`

### Контекст для приложения

**Общие бизнес-правила, которые могут помочь для поиска багов:**

1. Бронь имеет некоторую валюту
2. Стоимость брони должна рассчитываться относительно указанной валюты по курсу
3. При отмене брони должны возвращаться деньги
4. Мы можем искать бронь по ее идентификатору
5. Можем искать по набору фильтров в виде даты и категории
6. Валюта обновляется динамически
7. Бронирование:
   - дата начала бронирования не может равняться дате конца бронирования
8. Отмена бронирования:
   - Бронирование можно отменить, если дата заезда > текущей даты
     - При отмене бронирования расчитывается штраф отмены, штраф - это положительное число
     - При поиске по фильтрам дата учитывается включительно.
9. Нельзя создать бронь с датой заезда и выезда в один и тот же день.

**Условия для работы пользовательского ввода с консоли**

1. Команды приложения, для которых имеет смысл операции отмены, должны быть отменяемы.
2. Отсутствие команд в истории и вызов метода отмены последней команды не должны приводить к ошибке
3. Отмена невыполненных команд не должна приводить к ошибке
4. Выполненные команды сохраняются в историю команд
