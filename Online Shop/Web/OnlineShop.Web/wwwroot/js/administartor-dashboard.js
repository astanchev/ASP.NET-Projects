const categories = document.getElementsByClassName("category-name");
//const btnAddCategory = document.getElementsByClassName("btn-add-section")[0];

for (const category of categories) {
    category.addEventListener('click', loadSubCategories);
}

async function loadSubCategories(e) {
    e.preventDefault();
    e.stopPropagation();

    const container = e.target.parentElement;

    if (!container.classList.contains("category-name")) {
        return;
    }

    const btnSubCategory = container.getElementsByClassName('btn-subCategory')[0];
    btnSubCategory.addEventListener('click', showForm);

    if (container.dataset.open === "Open") {

        container.dataset.open = "Closed";
        btnSubCategory.style.display = "none";

        const pSubCategories = container.querySelectorAll("p.subcategory-name");

        for (const subCategory of pSubCategories) {
            container.removeChild(subCategory);
        }

    } else {

        container.dataset.open = "Open";
        btnSubCategory.style.display = "block";

        var token = document.querySelector('input[name="__RequestVerificationToken"]').value;

        const categoryId = container.dataset.id;
        const url = `/api/CategoriesData/${categoryId}`;

        const subCategories = await (await fetch(url, {
            headers: { 'X-CSRF-TOKEN': token }
        })).json();

        for (const subCategory of subCategories) {
            let p = createElement('p', subCategory.name, { className: 'subcategory-name' });

            p.dataset.id = subCategory.id;

            container.appendChild(p);
        }
    }
}

function closeForm(e) {
    e.preventDefault();

    const form = e.target.parentElement.parentElement;

    if (form.style.display === "none") {
        form.style.display = "block";
    } else {
        form.style.display = "none";
    }
}

function showForm(e) {
    e.preventDefault();

    const form = e.target.parentElement.nextElementSibling;

    if (form.style.display === "none") {
        form.style.display = "block";
    } else {
        form.style.display = "none";
    }
}

function createElement(type, content, attributes) {
    const result = document.createElement(type);

    if (attributes !== undefined) {
        Object.assign(result, attributes);
    }

    if (Array.isArray(content)) {
        content.forEach(append);
    } else {
        append(content);
    }

    function append(node) {
        if (typeof node === 'string') {
            node = document.createTextNode(node);
        }

        result.appendChild(node);
    }

    return result;
}
