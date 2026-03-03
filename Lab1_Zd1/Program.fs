open System


//Zadanie 1
//(*
let newDayList()=
    ["Понедельник";"Вторник";"Среда";"Четверг";
        "Пятница";"Суббота";"Воскресенье"]

let askUser()=
    printfn"Введите порядковый номер дня недели (1-7): "
    int (Console.ReadLine())

//Поиск для недели по номеру
let findDay number days= 
    if number >=1 && number <=7 then
        Some (List.item (number-1) days)
    else 
        None

//Вывод ошибки или результата
let showResult day= 
    match day with
    | Some d-> printfn"Выбран день недели: %s "d
    | None -> printfn"Некорректный ввод,введите другое число."

[<EntryPoint>]  
let main args =
    let days=newDayList()
    let input=askUser()
    showResult(findDay input days)
    0

//*)

//Zadanie 2

//(*

let rec containsDigit (number: int) (k: int) : bool =
    if number = 0 then
        k = 0
    else
        let lastDigit = abs(number % 10) 
        if lastDigit = k then 
        //Если последняя цифра числа равна искомой то возвращаем true
            true
        else
        //Иначе ищем дальше
            containsDigit (number / 10) k 

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


//*)

//Zadanie 3

//(*
//Функции в которых по факту просиходит весь процесс
//Элемент по индексу
let rec getItem index list = 
    match list with
    | [] -> failwith "Индекс вне диапазона"      
    | head :: tail ->                             
        if index = 0 then
            head                     
        else 
            getItem (index - 1) tail              

//Добавить элемент в конец списка
let rec addToEnd element list = 
    match list with
    | [] -> [element]                              
    | head :: tail ->                               
        head :: (addToEnd element tail)             

//Удалить элемент из списка по значению
let rec removeByValue value list = 
    match list with
    | [] -> []                                      
    | head :: tail ->
        if head = value then
            tail                    
        else
            head :: (removeByValue value tail)      

//Проверить существование элемента в списке
let rec contains element list = 
    match list with
    | [] -> false                                   
    | head :: tail ->
        if head = element then
            true                  
        else 
            contains element tail                   


//Добавить к концу первого списка второй список(сцепка)
let rec append list1 list2 = 
    match list1 with
    | [] -> list2                                   
    | head :: tail ->                                
        head :: (append tail list2)                  


let rec length list = 
    match list with
    | [] -> 0//Если пустой список длина 0
    | _ :: tail -> 1 + length tail//Иначе 1+длина хвоста




let readList () =
    printf "Введите числа через пробел: "
    //Разделяем строку по пробелам
    let input = Console.ReadLine().Split(' ')
    //Строки в числа 
    List.ofArray input |> List.map int
    

// Ввод одного числа
let readNumber prompt =
    printf "%s" prompt
    //Считываем строку и превращаем в число
    int(Console.ReadLine()) 



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
//*)
