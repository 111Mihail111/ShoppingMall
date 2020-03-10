/***ИНИЦИАЛИЗАЦИЯ СКРИПТОВ СТРАНИЦЫ***/

$(function () {
    AjaxQueryGetCity();
    CategoryStoreDdl();
})

/***ИНИЦИАЛИЗАЦИЯ СКРИПТОВ СТРАНИЦЫ***/



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

//Добавление контрола
function AddControl(button) {
    
    let element = button.parentElement.parentElement;
    let inputCollection = element.getElementsByTagName("input");
    let countElements = element.childElementCount - 1;

    let cloneElement = element.cloneNode(true);
    cloneElement.id += countElements;
    cloneElement.getElementsByTagName('button')[0].disabled = false;
    cloneElement.getElementsByTagName('span')[0].innerText = '+';
    cloneElement.getElementsByTagName("input")[0].value = "";

    let container = element.parentElement;
    container.append(cloneElement);
    inputCollection = container.getElementsByTagName("input");

    UpdateNameAttribute(inputCollection);
}

//Смена кнопки
function ChangedButton(button) {
    
    let buttonText = button.childNodes[1].innerText;
    let container = button.parentNode.parentNode;

    if (buttonText === '+') {
        button.childNodes[1].innerText = '-';
        button.disabled = true;
        AddControl(button);
        button.disabled = false;
    }
    else {
        let inputCollection = button.parentElement.parentElement.parentElement.getElementsByTagName("input");
        container.parentNode.removeChild(container);
        UpdateNameAttribute(inputCollection);
    }
}

//Обновление атрибута у контролов
function UpdateNameAttribute(input) {
    for (var i = 0; i < input.length; i++) {
        let array = input[i].name.split(".");
        if (array.length < 3) {
            input[i].name = input[i].name.replace(/[0-9]/, i)
            continue;
        }
        input[i].name = "";
        for (var index = 0; index < array.length; index++) {
            if (index === 1) {
                array[1] = array[1].replace(/[0-9]/, i);
            }
            if (index === 2) {
                input[i].name += array[index];
                continue;
            }
            input[i].name += array[index] + ".";
        }
    }
}

/***КЛОНИРОВАНИЕ КОНТРОЛОВ***/



/***КЛОНИРОВАНИЕ ПАНЕЛИ КОНТРОЛОВ***/

//Глобальная переменная с клонированным объектом
var _panel;

//Клонирование панели при входе на страницу
function ClonePanelRegionalDate() {
    _panel = document.getElementById("Panel").cloneNode(true);
}

//Добавление новой панели
function AddNewPanel(button) {

    let container = document.getElementById("PanelContainer");
    var clonePanel = _panel.cloneNode(true);
    let elementCount = container.childElementCount;

    clonePanel.id += elementCount;

    var inputListContainer = clonePanel.getElementsByTagName("input");
    for (var i = 0; i < inputListContainer.length; i++) {
        inputListContainer[i].name = inputListContainer[i].name.replace(/[0-9]/, elementCount);
    }

    button.children[0].innerText = "Удалить город";
    button.attributes[0].value = "bDetetePanel";
    button.attributes[1].value = "DeletePanel(this)";

    container.append(clonePanel);
}

//Удаление панели
function DeletePanel(button) {
    button.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.remove();
    UpdatePanel();
}

//Обновление панели
function UpdatePanel() {
    let panelContainer = document.getElementById("PanelContainer");
    let count = panelContainer.childElementCount;
    for (let index = 0; index < count; index++) {
        let inputCollection = panelContainer.children[index].getElementsByTagName("input");
        for (let i = 0; i < inputCollection.length; i++) {
            inputCollection[i].name = inputCollection[i].name.replace(/[0-9]/, index);
        }
    }
}

/***КЛОНИРОВАНИЕ ПАНЕЛИ КОНТРОЛОВ***/



/***РАБОТА С КАТЕГОРИЯМИ ТОВАРОВ***/

//Глобальная модель для ajax запроса
var _StoreCategoryByTypes = {
    CategoryName: null,
    CategoryStoreId: []
};

//Инициализация DropDownList'а
function CategoryStoreDdl () {

    let input = document.getElementById('Search');
    let dropDownList = document.getElementById('DropDownList');

    input.onblur = function () {
        dropDownList.classList.replace('visible', 'invisibly');
        input.value = "";
        if (input.previousElementSibling === null) {
            input.required = true;
            return;
        }

        input.parentNode.style.borderColor = "#ced4da";
        input.required = false;
    }

    input.onfocus = function () {
        dropDownList.classList.replace('invisibly', 'visible');
    }

    input.oninput = function () {
        _StoreCategoryByTypes.CategoryName = input.value;
        AjaxQueryGetDataCategory(_StoreCategoryByTypes);
    }

    _StoreCategoryByTypes.CategoryName = input.value;
    AjaxQueryGetDataCategory(_StoreCategoryByTypes);
}

//Ajax запрос получения категорий из БД для DropDownList'а
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

                let liHeader = document.createElement("li");
                liHeader.style.fontWeight = "bold";
                liHeader.className = "mt-2 ml-2 mb-1"
                liHeader.innerHTML = result[i].TypeCategoryName;
                liHeader.id = "Header";
                liHeader.value = 1 + i;

                dropDownList.append(liHeader);

                for (index = 0; index <= result[i].CategoryStores.length - 1; index++) {

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
    let input = document.getElementById('Search');
    input.focus();

    _StoreCategoryByTypes.CategoryName = input.value;
    AjaxQueryGetDataCategory(_StoreCategoryByTypes);
}

//Добавление тэга в лист Категорий
function AddTagByList(liElement) {

    let divContainer = document.getElementById("Category");
    document.getElementById('Search').value = "";

    let button = CreateButton(liElement);
    divContainer.insertAdjacentElement('afterbegin', button);

    _StoreCategoryByTypes.CategoryStoreId.push(button.value);
    CreateHiddenField(liElement);
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
    RemoveHiddenField(button);
    button.remove();

    let index = _StoreCategoryByTypes.CategoryStoreId.indexOf(button.value);
    _StoreCategoryByTypes.CategoryStoreId.splice(index, 1);

    let input = document.getElementById('Search');
    _StoreCategoryByTypes.CategoryName = input.value;

    AjaxQueryGetDataCategory(_StoreCategoryByTypes);
}

//Создание скрытых полей и вставка в разметку
function CreateHiddenField(liElement) {

    let liHeader = GetHeaderDropDownList(liElement);

    let inputHeader = document.createElement("input");
    inputHeader.id = "TypeCategoryStory";
    inputHeader.value = liHeader.value;
    inputHeader.name = GetIndexByNameInputHeader(inputHeader);

    let inputElement = document.createElement("input");
    inputElement.id = "CategoryStore";
    inputElement.value = liElement.value;
    inputElement.textContent = liElement.textContent;
    inputElement.name = "TypeCategoryStores[" + inputHeader.name.match(/[0-9]/)[0] + "].CategoryStores[0].CategoryStoreId";

    document.getElementById("InputHiddenFields").append(inputHeader, inputElement);
}

//Получение индекса для инпут хедера
function GetIndexByNameInputHeader(inputHeader) {

    let hiddenFields = document.getElementById("InputHiddenFields");
    let arrayInput = hiddenFields.getElementsByTagName("input");

    let count = hiddenFields.childElementCount;
    for (let i = count; i => 0; i--) {

        let isNull = arrayInput.namedItem("TypeCategoryStores[" + i + "].TypeCategoryStoryId");
        if (isNull) {
            index = i++;
            return inputHeader.name = "TypeCategoryStores[" + i + "].TypeCategoryStoryId";
        }
        else if (i === 0) {
            return inputHeader.name = "TypeCategoryStores[" + i + "].TypeCategoryStoryId";
        }
    }
}

//Получение хедера из dropDownList'a
function GetHeaderDropDownList(liElement) {
    let liHeader = liElement;
    while (liHeader.id != "Header") {
        liHeader = liHeader.previousSibling;
    }

    return liHeader;
}

//Удаление скрытых полей
function RemoveHiddenField(button) {
    let text = button.innerText;
    let hiddenFields = document.getElementById("InputHiddenFields").getElementsByTagName("input");
    let index = 0;
    for (var i = 0; i < hiddenFields.length; i++) {
        if (hiddenFields[i].innerText === text) {
            hiddenFields[i].remove();
            hiddenFields[i - 1].remove();
            i = -1;
            index = 0;
            continue;
        }
        if (hiddenFields[i].id === "TypeCategoryStory") {
            hiddenFields[i].name = hiddenFields[i].name.replace(/[0-9]/, index);
            hiddenFields[i + 1].name = hiddenFields[i + 1].name.replace(/[0-9]/, index);
            index++;
        }
    }
}

/***РАБОТА С КАТЕГОРИЯМИ ТОВАРОВ***/



/***РАБОТА С FileUploader***/

//Получение данных файла
function GetDataFiles(fileUploader) {

    let spanAddImage = fileUploader.previousElementSibling;
    let imageInfo = document.getElementById("ImageInfo");

    if (imageInfo.children[0].children.length === 0) {

        var fileName = CreateSpan("FileName");
        var fileSize = CreateSpan("FileSize");
        fileSize.style.color = "grey";
        fileSize.className = "ml-2";

        var fileRemove = CreateSpan("FileRemove");
        fileRemove.className = "custom-close ml-3";
        fileRemove.addEventListener("mousedown", function () { RemoveImage(this) }, false);
        fileRemove.style.color = "grey";
    }

    if (fileUploader.files.length === 0) {
        spanAddImage.innerText = "Добавить изображение";

        imageInfo.className = "invisible";
        imageInfo.children[0].remove();
        imageInfo.children[0].children[2].remove();
        imageInfo.children[0].children[1].remove();
        imageInfo.children[0].children[0].remove();

        return;
    }

    spanAddImage.innerText = "Изменить изображение";

    imageInfo.className = "visible";
    let childDiv = imageInfo.children[0];
    childDiv.append(fileName, fileSize, fileRemove);
    childDiv.children[0].innerText = fileUploader.files[0].name;
    childDiv.children[1].innerText += CovertToMegabyte(fileUploader.files[0].size).toFixed(2) + " КБ";

    let formData = new FormData();
    formData.append("imageFile", fileUploader.files[0]);
    AjaxQueryGetImage(formData);
}

//Создание span тэга
function CreateSpan(elementId) {
    let span = document.createElement("span");
    span.id = elementId;
    return span;
}

//Конвертация байтов в мегабайты
function CovertToMegabyte(byte) {
    return byte / 1024;
}

//Ajax запрос по получения картинки и отрисовки ее в UI
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
        });
}

//Удаление картинки
function RemoveImage(span) {
    let divContainer = span.parentElement;

    let count = divContainer.childElementCount;
    for (var i = count - 1; i <= count; i--) {
        if (i === -1) {

            let image = divContainer.previousElementSibling;
            if (image != null) {
                image.remove();
            }

            let fileUploader = document.getElementById("FileUploader");
            fileUploader.value = "";
            fileUploader.previousElementSibling.innerText = "Добавить изображение";

            return;
        }
        divContainer.children[i].remove();
    }

}

/***РАБОТА С FileUploader***/



/***СКРИПТ ВАЛИДАЦИИИ***/

//Валидирование формы
(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = document.getElementsByClassName('needs-validation');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();

//Вывести сообщение ошибок валидации
function DisplayValidationErrorMessages() {

    ValidateCategory();
    var invalidValidateCount = 0;
    document.getElementById("ErrorValidate").style.display = "";

    let inputCollection = document.getElementById("OnlineShop").getElementsByTagName("input");
    for (var i = 0; i < inputCollection.length; i++) {

        let element = inputCollection[i];
        if (element.getAttribute("required") === null) {
            continue;
        }

        if (element.validity.valid === false) {
            invalidValidateCount++;
            document.getElementById("MessageInvalid" + element.id).style.display = "";
        }
        else {
            document.getElementById("MessageInvalid" + element.id).style.display = "none";
        }
    }

    if (invalidValidateCount === 0) {
        document.getElementById("ErrorValidate").style.display = "none";
    }
}

//Валидация категории
function ValidateCategory() {
    let divCategory = document.getElementById("Category");

    let inputSearch = document.getElementById("Search");
    if (inputSearch.previousElementSibling === null) {
        inputSearch.required = true;
        divCategory.style.borderColor = "red";
        return;
    }

    divCategory.style.borderColor = "green";
    inputSearch.required = false;
}

/***СКРИПТ ВАЛИДАЦИИИ***/



/***РАБОТА С DropDownlList ГОРОДОВ***/

//Модель городов
var _Cities = {
    Id: null,
    Name: null
};

//Ajax запрос получения городов из БД для DropDownList'а
function AjaxQueryGetCity() {
    $.ajax({
        type: "POST",
        url: "/Shops/GetCities/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (cities) {
            for (var i = 0; i < cities.length; i++) {
                let option = document.createElement('option');
                option.value = cities[i].Id;
                option.text = cities[i].Name;
                document.getElementById("RegionalDateStore").insertAdjacentElement("beforeEnd", option);
            }
            ClonePanelRegionalDate();
        }
    });
}


/***РАБОТА С DropDownlList ГОРОДОВ***/