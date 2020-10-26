# StudentsGroups
Сервис, отвечающий за ведение данных студентов.

Сервис ответственен за сущности:
1. Студент
* ID (required, PK). Можно использовать любой вариант. GUID. Это поле системное, изменение данного поля не допускается.
* Пол (обязательное поле).
* Фамилия (обязательное, максимальная длина 40 символов)
* Имя (обязательное, максимальная длина 40 символов)
* Отчество ( не обязательное, максимальная длина 60 символов)
* Уникальный идентификатор студента (not required, должен быть уникальным в рамках всех студентов, минимальная длина 6 символов, максимальная длина 16). Опциональный, например мы хотим задать для студента позывной, но не хотим чтобы два студента были с одинаковыми позывными.
2. Группа
* ID (required, PK). Можно использовать любой вариант. GUID. Это поле системное, изменение данного поля не допускается.
* Имя группы. (обязательное, максимальная длина 25 символов)

Студент может находится одновременно в нескольких группах (многие ко многим).

Контроллеры содержат следующие методы:
1) Создание/удаление/редактирование студента
2) Создание/удаление/редактирование группы.
3) Добавление/Удаление студента из группы.
4) Получение списка студентов с возможностью фильтрации по полям (Пол, ФИО, уникальный идентификатор, название группы) и ограничением по результату (пагинация).
a. Результат - список где каждый элемент содержит поля: ID, ФИО, уникальный идентификатор, список групп через запятую.
5) Получение списка групп с возможностью фильтрации по полю «Имя группы».
a. Результат - список где каждый элемент содержит поля: ID, Имя группы, кол-во студентов в группе.
