addEventListener("load", () => {
    let user = JSON.parse(sessionStorage.getItem("id")) || []
    alert(user)
    sessionStorage.setItem("id", JSON.stringify(user))
    drawProduct()
})
const drawShoppingBag = (product) => {

    let tmp = document.getElementById("temp-row");
    let cloneProduct = tmp.content.cloneNode(true)
    let url = `./pictures/${product.imgPath}.jpg`
    cloneProduct.querySelector(".image").style.backgroundImage = `url(${url})`
   /* cloneProduct.querySelector(".image").src = "./pictures/" + product.imgPath + ".jpg";*/
   /* cloneProduct.querySelector("h1").textContent = product.productName*/
   
    cloneProduct.querySelector(".itemName").textContent = product.productName
    cloneProduct.querySelector(".itemNumber").innerText = product.price
    cloneProduct.querySelector(".expandoHeight").addEventListener('click', () => { deleteFromCart(product) })
    document.querySelector("tbody").appendChild(cloneProduct)
}
const deleteFromCart = (product) => {
    alert("delet")
    let products = sessionStorage.getItem("shopingBag");
    products = JSON.parse(products);
    let i = 0;
    for (; i < products.length; i++) {
        if (products[i].productsId == product.productsId){
        
            break;
        }
    }
    products.splice(i, 1);
    sessionStorage.setItem("shopingBag", JSON.stringify(products))
    window.location.href ="shoppingBag.html"
    drawProduct()
}
const drawProduct = async () => {
   
 let   productss = sessionStorage.getItem("shopingBag")
    productss = JSON.parse(productss)
    console.log(productss.length);
    let priceAllProduct = 0
    //document.getElementById("itemCount").textContent = products.length
    //document.querySelector("tbody").innerHTML = ''
    for (let i = 0; i < productss.length; i++) {
        drawShoppingBag(productss[i])
        priceAllProduct += productss[i].price;
       
    }
    document.getElementById("totalAmount").innerHTML = priceAllProduct+'$'
}
const generateDate = () => {
    const date = new Date();
    let day = date.getDate();
    let month = date.getMonth() + 1
    let year = date.getFullYear()
    let currentDate = year + "-" + month + "-" + day;
    return currentDate
}
const placeOrder = async () => {
    let shopingBag = JSON.parse(sessionStorage.getItem("shopingBag")) || []
    let userId = JSON.parse(sessionStorage.getItem("id")) || []
    if (userId && shopingBag.length != 0) {
        let currentProduct = {}
    }
}