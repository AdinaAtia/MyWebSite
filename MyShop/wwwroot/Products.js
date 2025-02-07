addEventListener("load", () => {
    let product =  []
    let category = []
    sessionStorage.setItem("category", JSON.stringify(category))
    sessionStorage.setItem("shopingBag", JSON.stringify(product))
    document.querySelector("#ItemsCountText").textContent = product.length
    filterProducts()
    drawCategory()
})
const getData = async () => {
    let search =
    {
        desc: document.querySelector("#desc").value,
        minPrice: parseInt(document.querySelector("#minPrice").value),
        maxPrice: parseInt(document.querySelector("#maxPrice").value),
        categoryIds: sessionStorage.getItem("category")

    }
    return search
}
const filterProducts = async () => {
    console.log("frftsdfcsytfgvvbruhdfjbvgrufhbrhfbfhuigb");
    let { desc, minPrice, maxPrice, categoryIds } = await getData()
    categoryIds = JSON.parse(categoryIds)
    console.log("adina"+categoryIds);
    let url = `api/Product/`;
    if (desc || maxPrice || minPrice || categoryIds.length != 0) {

        url += '?'
        if (desc)
            url += `&desc=${desc}`
        if (minPrice)
            url += `&minPrice=${minPrice}`
        if (maxPrice)
            url += `&maxPrice=${maxPrice}`
     
        if (categoryIds.length != 0) {
            console.log("adinaaaaaaa" + categoryIds);
            for (let i = 0; i < categoryIds.length; i++)
                url += `&categoryId=${categoryIds[i]}`
        }
    }
    try {
        console.log("url" + url);
        const responsePost = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
                /* nameSearch: nameSearch,*/
                desc: desc,
                minPrice: minPrice,
                maxPrice: maxPrice,
                categoryIds: categoryIds
            }
        });
        if (responsePost.status == 204)
            alert("not found products")
        if (!responsePost.ok) {
           
            throw new Error(`HTTP error! status:${response.status}`)
        }
        if (responsePost.ok) {

       
        }
        const dataPost = await responsePost.json();
        console.log("121323333"+dataPost);
        document.getElementById("counter").textContent = dataPost.length
        console.log(document.getElementById("counter").textContent);
        drawProducts(dataPost);
    }
    catch (error) {

        alert(" בפלטור יש לכם שגיאה")
    }
}

const MoveToLogin = () => {
    window.location.href = "home.html"
}
const MoveToUpdate = () => {
    window.location.href = "updateUser.html"
}

const drawTemplate = (product) => {

    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./pictures/" + product.imgPath + ".jpg";
    cloneProduct.querySelector("h1").textContent = product.productName
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".desc").innerText = product.decripition

    cloneProduct.querySelector(".bag").addEventListener('click', () => { addToCart(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const drawProducts = async (products) => {
    document.getElementById("PoductList").innerHTML = ""
    for (let i = 0; i < products.length; i++) {
        drawTemplate(products[i])
    }
}
const addToCart = (product) => {
    let products = sessionStorage.getItem("shopingBag")
    products = JSON.parse(products)
    products.push(product)
    sessionStorage.setItem("shopingBag", JSON.stringify(products))
    document.querySelector("#ItemsCountText").textContent = parseInt(document.querySelector("#ItemsCountText").textContent) + 1
}
const addCategory = async () => {
    try {
        const responsePost = await fetch('api/Category', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },

        });
        if (responsePost.status == 204)
            alert("not found categories")
        if (!responsePost.ok) {
            throw new Error(`HTTP error! status:${response.status}`)
        }
        const dataPost = await responsePost.json();
        console.log("vst");
        console.log(dataPost);
        return (dataPost);

    }
    catch (error) {

        alert("  בקבלת הקטגוריות יש לכם שגיאה")
    }



}
const drawCategory = async () => {
    category = await addCategory()
    console.log("11111"+category)
    for (let i = 0; i < category.length; i++) {
        let tmp = document.getElementById("temp-category");
        let cloneCategory = tmp.content.cloneNode(true)
        cloneCategory.querySelector("input").id = i
        cloneCategory.querySelector("input").addEventListener('change', () => { filterCategory(category[i], i) })
        cloneCategory.querySelector("label").textContent = category[i].categoryName

        document.getElementById("categoryList").appendChild(cloneCategory)
    }
}
const filterCategory = (category, index) => {
    const input = document.getElementById(index)

    if (input.checked) {
     
        let categories = sessionStorage.getItem("category")
/*        console.log(categories)*/
        categories = JSON.parse(categories)
        categories.push(category.id)
        sessionStorage.setItem("category", JSON.stringify(categories))
    }
    else {
        let categories = sessionStorage.getItem("category")
        console.log(categories)
        categories = JSON.parse(categories)
        let i = 0;
        for (; i < categories.length; i++) {
            if (categories[i] == category.id)
                break;
        }
        categories.splice(i, 1);
        sessionStorage.setItem("category", JSON.stringify(categories))
    }
  
    filterProducts()
   

}
