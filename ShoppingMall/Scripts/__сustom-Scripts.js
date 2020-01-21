/***РАСКРЫТИЕ/СОКРЫТИЕ ЭЛЕМЕНТОВ МЕНЮ***/

//Создание меню кнопок
function CreateMenuAcordion(button) {

    //Склеиваем id и находим по нему элемент
    var menuButton = document.getElementById("Menu" + button.id);

    //Получаем дочерний элемент
    var element = button.childNodes[1];

    //Получаем стиль под определенным индексом листа
    var divClass = menuButton.classList[1];

    if (divClass == "invisibly") {

        //Подменяем стили
        element.className = 'fa fa-chevron-circle-up';
        menuButton.classList.replace('invisibly', 'visible');
    }
    else if (divClass == "visible") {

        //Подменяем стили
        element.className = 'fa fa-chevron-circle-down';
        menuButton.classList.replace('visible', 'invisibly');
    }

}

/***РАСКРЫТИЕ/СОКРЫТИЕ ЭЛЕМЕНТОВ МЕНЮ***/


/***КЛОНИРОВАНИЕ КОНТРОЛОВ***/

//Создание контрола
function CreateControl(containerElement) {

    //Поиск и получение элемента
    let elementContainer = containerElement.getElementsByClassName("row");

    //Получаем общее количество всех элементов основного контейнера
    let countElementContainer = containerElement.childElementCount;

    //Клонирование элемента
    let cloneElement = elementContainer[0].cloneNode(true);

    //Увеличиваем id клонированного элемента
    cloneElement.id += countElementContainer;

    //Находим контрол input в контейнере элементов
    let inputControl = cloneElement.getElementsByTagName('input');

    //Подменяем атрибут
    cloneElement.getElementsByTagName('button')[0].disabled = false;

    //Подменяем текст
    cloneElement.getElementsByTagName('span')[0].innerText = '+';

    //Меняем атрибут нумеруя его индекс
    inputControl[0].name = "UserControl2[" + countElementContainer + "]." + inputControl[0].id
    inputControl[0].value = "";

    //Вставляем клонированный элемент
    containerElement.append(cloneElement);
}

//Смена кнопки
function ChangedButton(button) {

    //Получение символа кнопки
    let buttonText = button.childNodes[1].innerText;

    //Получение дочернего элемента контейнера
    let container = button.parentNode.parentNode;

    if (buttonText === '+') {

        //Изменение текста у кнопки
        button.childNodes[1].innerText = '-';

        //Блокируем кнопку
        button.disabled = true;

        //Передача контейнера в метод создания контролов
        CreateControl(container.parentNode);

        //Разблокируем кнопку
        button.disabled = false;
    }
    else {

        //Удаление элемента из контейнера
        container.parentNode.removeChild(container);
    }

}

/***КЛОНИРОВАНИЕ КОНТРОЛОВ***/


/***КЛОНИРОВАНИЕ ПАНЕЛИ КОНТРОЛОВ***/

//Глобальная переменная с клонированным объектом
var _panel;

//Клонирование панели при входе на страницу
$(function () {
    _panel = document.getElementById("Panel").cloneNode(true);
})

//Добавление новой панели
function AddNewPanel(button) {

    //Получение основного контейнера элементов
    let container = document.getElementById("PanelContainer");

    //Клонирование панели из глобальной переменной
    var clonePanel = _panel.cloneNode(true);

    //Увеличение его id от общего количества записей
    clonePanel.id += container.childElementCount;

    //Смена текста кнопки
    button.children[0].innerText = "Удалить город";

    //Назначение id
    button.attributes[0].value = "bDetetePanel";

    //Назначение события
    button.attributes[1].value = "DeletePanel(this)";

    //Вставка элемента
    container.append(clonePanel);
}

//Удаление панели
function DeletePanel(button) {

    //Получение отца элемента и его удаление
    button.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.remove();
}

/***КЛОНИРОВАНИЕ ПАНЕЛИ КОНТРОЛОВ***/


/***РАБОТА С КАТЕГОРИЯМИ ТОВАРОВ***/

$(function () {

    //Получение id input'a
    let input = document.getElementById('Search')

    //Получение выпадающего списка
    let dropDownList = document.getElementById('DropDownList');

    //Самовызывающеесе событие, если фокус есть на элементе
    input.onblur = function () {

        //Находим определенный стиль и заменяем на другой
        dropDownList.classList.replace('visible', 'invisibly');
    }

    //Самовызывающеесе событие, если фокуса нет на элементе
    input.onfocus = function () {

        //Находим определенный стиль и заменяем на другой
        dropDownList.classList.replace('invisibly', 'visible');
    }

    //Отслеживаем ввод текста
    input.oninput = function () {

        var model = {
            CategoryName: input.value
        };
debugger;
        $.ajax({
            type: "POST",
            data: JSON.stringify(model),
            url: "/Shops/GetCategoryShopByName/",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (res) {

                for (i = 0; i < res.length; i++) {

                    $("#DropDownListHeader").html(res[i].TypeCategoryName);

                    for (index = 0; index < res[0].CategoryStores.length; index++) {

                        $("#DropDownListElement").html(res[i].CategoryStores[index].CategoryName);

                    }
                }
                
            }
        });
    }
})


function FocusOnInput() {

    //Наводим фокус на элемент
    document.getElementById('Search').focus();

}

function AddTagByList(liElement) {

    let divContainer = document.getElementById("Category");

    divContainer.insertAdjacentElement('afterbegin', CreateElement(liElement));
}

function CreateElement(liElement) {

    let i = document.createElement("i");
    i.classList = 'fa fa-close';

    let button = document.createElement("button");
    button.classList = "btn";
    button.style.padding = '5px 9px 5px 9px';
    button.style.margin = '6px 0px 6px 6px';
    button.style.border = '1px solid #aaaaaa';
    button.style.color = '#333';
    button.textContent = liElement.innerText;
    button.disabled = true;
    button.append(i);

    return button;
}

/***РАБОТА С КАТЕГОРИЯМИ ТОВАРОВ***/