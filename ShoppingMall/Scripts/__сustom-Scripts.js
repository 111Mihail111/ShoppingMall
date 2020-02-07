/***РАСКРЫТИЕ/СОКРЫТИЕ ЭЛЕМЕНТОВ МЕНЮ***/

//Создание меню кнопок
function CreateMenuAcordion(button) {

    var menuButton = document.getElementById("Menu" + button.id);
    var element = button.childNodes[1];
    var divClass = menuButton.classList[1];

    if (divClass == "invisibly") {
        element.className = 'fa fa-chevron-circle-up';
        menuButton.classList.replace('invisibly', 'visible');
    }
    else if (divClass == "visible") {
        element.className = 'fa fa-chevron-circle-down';
        menuButton.classList.replace('visible', 'invisibly');
    }

}

/***РАСКРЫТИЕ/СОКРЫТИЕ ЭЛЕМЕНТОВ МЕНЮ***/



/***КЛОНИРОВАНИЕ КОНТРОЛОВ***/

//Создание контрола
function CreateControl(containerElement) {

    let elementContainer = containerElement.getElementsByClassName("row");
    let countElementContainer = containerElement.childElementCount;

    let cloneElement = elementContainer[0].cloneNode(true);
    cloneElement.id += countElementContainer;
    cloneElement.getElementsByTagName('button')[0].disabled = false;
    cloneElement.getElementsByTagName('span')[0].innerText = '+';

    let inputControl = cloneElement.getElementsByTagName('input');
    inputControl[0].name = "UserControl2[" + countElementContainer + "]." + inputControl[0].id
    inputControl[0].value = "";

    containerElement.append(cloneElement);
}

//Смена кнопки
function ChangedButton(button) {

    let buttonText = button.childNodes[1].innerText;
    let container = button.parentNode.parentNode;

    if (buttonText === '+') {

        button.childNodes[1].innerText = '-';
        button.disabled = true;
        CreateControl(container.parentNode);
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

//Глобальная модель для ajax запроса
var _model = {
    CategoryName: null,
    CategoryStoreId: []
};

//Инициализация DropDownList'а
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
        _model.CategoryName = input.value;
        AjaxQueryGetDataCategory(_model);
    }
})

//Ajax запрос получения данных из БД для DropDownList'а
function AjaxQueryGetDataCategory(model) {
    $.ajax({
        type: "POST",
        data: JSON.stringify(model),
        url: "/Shops/GetCategoryShopByName/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {

            let dropDownList = $("#DropDownListElements");
            dropDownList.empty();

            for (i = 0; i < result.length; i++) {

                if (result[i].CategoryStores.length === 0) {
                    continue;
                }

                let liHeader = document.createElement("li");
                liHeader.style.fontWeight = "bold";
                liHeader.className = "mt-2 ml-2 mb-1"
                liHeader.innerHTML = result[i].TypeCategoryName;

                dropDownList.append(liHeader);

                for (index = 0; index < result[i].CategoryStores.length; index++) {

                    let liElement = document.createElement("li");
                    liElement.className = "ml-3 mt-1";
                    liElement.innerHTML = result[i].CategoryStores[index].CategoryName;
                    liElement.value = result[i].CategoryStores[index].CategoryStoreId;
                    liElement.addEventListener('mousedown', function () { AddTagByList(this) }, false);

                    dropDownList.append(liElement);
                }

            }
        }
    });
}

//Наведение фокуса на input при нажатии на область div'а
function FocusOnInput() {

    //Наводим фокус на элемент
    document.getElementById('Search').focus();

    let input = document.getElementById('Search');
    _model.CategoryName = input.value;

    AjaxQueryGetDataCategory(_model);
}

//Добавление тэга в лист Категорий
function AddTagByList(liElement) {

    let divContainer = document.getElementById("Category");
    document.getElementById('Search').value = "";

    let button = CreateButton(liElement);
    divContainer.insertAdjacentElement('afterbegin', button);

    _model.CategoryStoreId.push(button.value)
}

//Создание кнопки
function CreateButton(liElement) {

    let i = document.createElement("i");
    i.classList = 'fa fa-close mr-1';
    i.addEventListener('mousedown', function () { RemoveButtonElement(this) }, false)

    let span = document.createElement('span');
    span.textContent = liElement.innerText;

    let button = document.createElement("button");
    button.classList = "btn";
    button.style.padding = '5px 9px 5px 9px';
    button.style.margin = '6px 0px 6px 6px';
    button.style.border = '1px solid #aaaaaa';
    button.style.color = '#333';
    button.value = liElement.value;
    button.disabled = true;

    button.append(i);
    button.append(span);

    return button;
}

//Удаление кнопки выбранного ранее элемента 
function RemoveButtonElement(iElement) {

    let button = iElement.parentElement;

    let index = _model.CategoryStoreId.indexOf(button.value);
    _model.CategoryStoreId.splice(index, 1);

    button.remove();
}

/***РАБОТА С КАТЕГОРИЯМИ ТОВАРОВ***/


/***РАБОТА С FileUploader***/
function GetDataFiles() {

    let fileUploader = document.getElementById("FileUploader");
    let spanAddImage = fileUploader.previousElementSibling;
    let imageInfo = document.getElementById("ImageInfo");
    debugger;
    if (imageInfo.children[0].children.length === 0) {

        var fileName = CreateSpan("FileName");
        var fileSize = CreateSpan("FileSize");
        fileSize.style.color = "grey";
        fileSize.className = "ml-2";
        
    }

    if (fileUploader.files.length === 0) {
        spanAddImage.innerText = "Добавить изображение";

        imageInfo.className = "invisible";
        imageInfo.children[0].remove();
        imageInfo.children[0].children[1].remove();
        imageInfo.children[0].children[0].remove();

        return;
    }

    spanAddImage.innerText = "Изменить изображение";

    imageInfo.className = "visible";
    let childDiv = imageInfo.children[0];
    childDiv.append(fileName, fileSize);
    childDiv.children[0].innerText = fileUploader.files[0].name;
    childDiv.children[1].innerText += CovertToMegabyte(fileUploader.files[0].size).toFixed(2) + " КБ";

    let formData = new FormData();
    formData.append("imageFile", fileUploader.files[0])
    AjaxQueryGetImage(formData);
}

function CreateSpan(elementId) {
    let span = document.createElement("span");
    span.id = elementId;
    return span;
}

function CovertToMegabyte(byte) {
    return byte / 1024;
}

function AjaxQueryGetImage(image) {
    $.ajax(
        {
            type: "POST",
            data: image,
            url: "/Shops/GetImage",
            contentType: false,
            processData: false,
            success: function (imageByte) {
                let image = document.createElement("img");
                image.src = "data:image/png;base64," + imageByte;
                image.className = "mt-2";
                image.style.width = "100%";

                document.getElementById("ImageInfo").insertAdjacentElement("afterbegin", image);
            },
            error: function () {
                alert("Произошла ошибка");
            }
        });
}

/***РАБОТА С FilUploader***/