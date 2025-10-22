
$(function() {

    $('.img-slide img:gt(0)').hide();

    setInterval(function(){

        $('.img-slide :first-child').fadeOut()

         .next('img').fadeIn()

         .end().appendTo('.img-slide');
    },

      4000);

})
