open System


//Zadanie 1
//(*
let NewDayList()=
    ["Понедельник";"Вторник";"Среда";"Четверг";"Пятница";"Суббота";"Воскресенье"]

let AskUser()=
    printfn"Введите порядковый номер дня недели (1-7): "
    int (Console.ReadLine())

let FindDay number days= //Поиск для недели по номеру
    if number >=1 && number <=7 then
        Some (List.item (number-1) days)
    else 
        None
    
let ShowResult day= //Вывод ошибки или результата
    match day with
    | Some d-> printfn"Выбран день недели: %s "d
    | None -> printfn"Некорректный ввод,введите другое число."

[<EntryPoint>]  
let main args =
    let days=NewDayList()
    let input=AskUser()
    ShowResult(FindDay input days)
    0

//*)

//Zadanie 2

(*

let rec containsDigit (number: int) (k: int) : bool =
    if number = 0 then
        k = 0
    else
        let lastDigit = abs(number % 10) 
        if lastDigit = k then //Если последняя цифра числа равна искомой то круто
            true
        else
            containsDigit (number / 10) k //Иначе не круто и ищем дальше

[<EntryPoint>]
let main argv =
    printf "Введите число: "
    let number = int(Console.ReadLine())
    printf "Введите цифру для поиска: "
    let k = int(Console.ReadLine())
    let result = containsDigit number k
    
    if result then
        printfn "Цифра %d найдена в числе %d" k number
    else
        printfn "Цифра %d не найдена в числе %d" k number
    
    0


*)

//Zadanie 3

(*
//Функции в которых по факту просиходит весь процесс

let rec getItem index list = //Элемент по индексу
    match list with
    | [] -> failwith "Индекс вне диапазона"      
    | head :: tail ->                             
        if index = 0 then head                     
        else getItem (index - 1) tail              


let rec addToEnd element list = //Добавить элемент в конец списка
    match list with
    | [] -> [element]                              
    | head :: tail ->                               
        head :: (addToEnd element tail)             


let rec removeByValue value list = //Удалить элемент из списка по значению
    match list with
    | [] -> []                                      
    | head :: tail ->
        if head = value then tail                    
        else head :: (removeByValue value tail)      


let rec contains element list = //Проверить существование элемента в списке
    match list with
    | [] -> false                                   
    | head :: tail ->
        if head = element then true                  
        else contains element tail                   


let rec append list1 list2 = //Добавить к концу первого списка второй список(сцепка)
    match list1 with
    | [] -> list2                                   
    | head :: tail ->                                
        head :: (append tail list2)                  


let rec length list = 
    match list with
    | [] -> 0                                        //Если пустой список длина 0
    | _ :: tail -> 1 + length tail                   //Иначе 1+длина хвоста




let readList () =
    printf "Введите числа через пробел: "
    let input = Console.ReadLine().Split(' ')       //Разделяем строку по пробелам
    [ for i in 0 .. input.Length - 1 -> int input.[i] ]  //Строки в числа

// Ввод одного числа
let readNumber prompt =
    printf "%s" prompt
    int(Console.ReadLine())                       //Считываем строку и превращаем в число



//Функции для красивого вывода и выбора

let doGetItem list = 
    let index = readNumber "Введите индекс: "
    try
        let item = getItem index list
        printfn "Элемент с индексом %d: %d" index item
    with
        | _ -> printfn "Ошибка: такого индекса нет"


let doAddToEnd list = 
    let value = readNumber "Введите число: "
    let newList = addToEnd value list
    printfn "Исходный список: %A" list
    printfn "Новый список: %A" newList


let doRemoveByValue list =
    let value = readNumber "Введите число для удаления: "
    let newList = removeByValue value list
    if newList = list then
        printfn "Число %d не найдено в списке" value
    else
        printfn "Исходный список: %A" list
        printfn "После удаления: %A" newList


let doContains list =
    let value = readNumber "Введите число для поиска: "
    if contains value list then
        printfn "Число %d найдено в списке" value
    else
        printfn "Число %d не найдено в списке" value


let doAppend list =
    printf "Введите второй список через пробел: "
    let input = Console.ReadLine().Split(' ')
    let list2 = [ for i in 0 .. input.Length - 1 -> int input.[i] ]
    let newList = append list list2
    printfn "Первый список: %A" list
    printfn "Второй список: %A" list2
    printfn "Результат сцепки: %A" newList


let doLength list =
    printfn "Длина списка: %d" (length list)


let showMenu () =
    printfn "\nВыберите операцию:"
    printfn "1: Получить элемент по индексу"
    printfn "2: Добавить элемент в конец"
    printfn "3: Удалить элемент по значению"
    printfn "4: Найти элемент (проверить наличие)"
    printfn "5: Сцепить с другим списком"
    printfn "6: Узнать длину списка"
    printf "Выполнить операцию под номером: "
    int(Console.ReadLine())


[<EntryPoint>]
let main args =
    printfn "===Работа со списками==="
    
    let numbers = readList ()
    printfn "\nВведеный список: %A" numbers
    
    let choice = showMenu ()
    printfn ""  
    
    match choice with
    | 1 -> doGetItem numbers
    | 2 -> doAddToEnd numbers
    | 3 -> doRemoveByValue numbers
    | 4 -> doContains numbers
    | 5 -> doAppend numbers
    | 6 -> doLength numbers
    | _ -> printfn "Неверный выбор"
    0
    *)
