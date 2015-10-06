function showBigImage(source) {
   // var img = document.getElementById('origImage');
    //img.style.display = 'table';
    
    var myDiv = document.getElementById(source);  

    var bigImg = document.getElementById('origImage');
    var resultSource = myDiv.style.backgroundImage.split('/img/')[1];
    resultSource = resultSource.replace(')', '');
    resultSource = '/img/' + resultSource.replace('400', '1000');    
    bigImg.src = resultSource;

    var wrapper = document.getElementById('bigImageWrapper');
    wrapper.style.display = 'block';
   

}

function hideBigImage(){
    var wrapper = document.getElementById('bigImageWrapper');
    wrapper.style.display = 'none';
    
}