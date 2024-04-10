(function ($) {

    "use strict";

    var searchPopup = function () {
        // open search box
        $('#header-nav').on('click', '.search-button1', function (e) {
            $('.search-popup').toggleClass('is-visible');
        });

        $('#header-nav').on('click', '.btn-close-search', function (e) {
            $('.search-popup').toggleClass('is-visible');
        });

        $(".search-popup-trigger").on("click", function (b) {
            b.preventDefault();
            $(".search-popup").addClass("is-visible"),
                setTimeout(function () {
                    $(".search-popup").find("#search-popup").focus()
                }, 350)
        }),
            $(".search-popup").on("click", function (b) {
                ($(b.target).is(".search-popup-close") || $(b.target).is(".search-popup-close svg") || $(b.target).is(".search-popup-close path") || $(b.target).is(".search-popup")) && (b.preventDefault(),
                    $(this).removeClass("is-visible"))
            }),
            $(document).keyup(function (b) {
                "27" === b.which && $(".search-popup").removeClass("is-visible")
            })
    }

    var initProductQty = function () {

        $('.product-qty').each(function () {

            var $el_product = $(this);
            var quantity = 0;

            $el_product.find('.quantity-right-plus').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($el_product.find('#quantity').val());
                $el_product.find('#quantity').val(quantity + 1);
            });

            $el_product.find('.quantity-left-minus').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($el_product.find('#quantity').val());
                if (quantity > 0) {
                    $el_product.find('#quantity').val(quantity - 1);
                }
            });

        });

    }

    function search() {
        $('.form-control').on('input', function () {
            var searchText = $(this).val().toLowerCase(); // Get the entered search text

            // Filter items based on the search text
            $('.product-card').each(function () {
                var productName = $(this).find('.card-title').text().toLowerCase(); // Get the product name
                // Show or hide the item based on whether the product name contains the search text
                $(this).toggle(productName.includes(searchText));
            });
        });
    }

    function filterProducts() {
        var selectedPrices = [];
        $('.price-filter:checked').each(function () {
            selectedPrices.push(parseFloat($(this).val()));
        });

        console.log("Selected Prices: ", selectedPrices);

        if (selectedPrices.length === 0) {
            $('.product-card').show();
        } else {
            $('.product-card').hide();
            $('.product-card').filter(function () {
                var productPrice = parseFloat($(this).attr('data-price'));
                return selectedPrices.some(function (price) {
                    return productPrice >= price;
                });
            }).show();
        }
    }

   /* function calculateTotal() {
        var totalPrice = 0;
        // Loop through each item in the cart
        console.log($(".itemcardbody").length);
        $(".itemcardbody").each(function () {
            console.log("Inside loop...");
            var quantity = parseInt($(this).find(".form-control").val());
            var priceString = $(this).find("#ItemPrice").text().replace("Rs.", "").trim();
            var price = parseFloat(priceString);
            totalPrice += quantity * price;
        });
        return totalPrice;
    }

    // Function to update total price display
    function updateTotal() {
        console.log("Running...");
        var totalPrice = calculateTotal();
        $("#totalPrice").text("Total: Rs." + totalPrice.toFixed(2));
    }*/

    $(document).ready(function () {
        $('.price-filter').on('change', function () {
            filterProducts();
        });
        /*$(".form-control").on("input", function () {
            updateTotal();
        });*/
        search();
        /*$(".aa-cart-link").on("click", function (event) {
            // Call the updateTotal function
            console.log("I am here");
            updateTotal();
        });*/
        
        searchPopup();
        initProductQty();
        
        

        var swiper = new Swiper(".main-swiper", {
            speed: 500,
            navigation: {
                nextEl: ".swiper-arrow-prev",
                prevEl: ".swiper-arrow-next",
            },
        });

        var swiper = new Swiper(".product-swiper", {
            slidesPerView: 4,
            spaceBetween: 10,
            pagination: {
                el: "#mobile-products .swiper-pagination",
                clickable: true,
            },
            breakpoints: {
                0: {
                    slidesPerView: 2,
                    spaceBetween: 20,
                },
                980: {
                    slidesPerView: 4,
                    spaceBetween: 20,
                }
            },
        });

        var swiper = new Swiper(".product-watch-swiper", {
            slidesPerView: 4,
            spaceBetween: 10,
            pagination: {
                el: "#smart-watches .swiper-pagination",
                clickable: true,
            },
            breakpoints: {
                0: {
                    slidesPerView: 2,
                    spaceBetween: 20,
                },
                980: {
                    slidesPerView: 4,
                    spaceBetween: 20,
                }
            },
        });

        var swiper = new Swiper(".testimonial-swiper", {
            loop: true,
            navigation: {
                nextEl: ".swiper-arrow-prev",
                prevEl: ".swiper-arrow-next",
            },
        });

    }); // End of a document ready

})(jQuery);