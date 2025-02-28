addEventListener("DOMContentLoaded", () => {
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
    window.location.href ="shopingBag.html"
    drawProduct()
}
let priceAllProduct = 0
const drawProduct = async () => {
   
 let   productss = sessionStorage.getItem("shopingBag")
    productss = JSON.parse(productss)
    console.log(productss.length);
   
    let itemCount = 0;
    //document.getElementById("itemCount").textContent = products.length
    //document.querySelector("tbody").innerHTML = ''
    for (let i = 0; i < productss.length; i++) {
        drawShoppingBag(productss[i])
        priceAllProduct += productss[i].price;
        itemCount += 1;
       
    }
    console.log(itemCount);
    document.getElementById("itemCount").innerHTML = itemCount
    document.getElementById("totalAmount").innerHTML = priceAllProduct + '$'
  
}
const generateDate = () => {
    const date = new Date();
    let day = date.getDate();
    let month = date.getMonth() + 1
    let year = date.getFullYear()
    let currentDate = year + "-" + month + "-" + day;
    return currentDate
}
//const placeOrder = async () => {
//    let shopingBag = JSON.parse(sessionStorage.getItem("shopingBag")) || []
//    let userId = JSON.parse(sessionStorage.getItem("id")) || []
//    if (userId && shopingBag.length != 0) {
//        let currentProduct = {}
//    }
//}
const detials = () => {
    let UserId = JSON.parse(sessionStorage.getItem("id"))
    let orderItems1 = JSON.parse(sessionStorage.getItem("shopingBag"))
    const OrderItems =[]
        orderItems1.map(t => {
            let object = { productId: t.productsId, quentity: 1 }
        console.log(object);
        OrderItems.push(object)
    })
    let OrderSum = priceAllProduct;
    return ({
         OrderSum, UserId, OrderItems,
    })
}
const placeOrder = async () => {
    if (priceAllProduct != 0) {
        if (sessionStorage.getItem("id")) {
            let alldetials = detials()
            console.log("aaaaaa",alldetials);

            const orderss = await fetch('api/Order', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },

                body: JSON.stringify(alldetials)

            });
           const ordderJson = await orderss.json();
            if (orderss.ok) {
                alert("ההזמנה נוספה בהצלחה")

                sessionStorage.setItem("shopingBag", JSON.stringify([]))
                window.location.href = "Products.html"
            }
        }
        else {
            alert("אינך רשום")
            window.location.href = "home.html"
        }
    }
    else {
        alert("הסל ריק")
        window.location.href = "Products.html";
    }

}
