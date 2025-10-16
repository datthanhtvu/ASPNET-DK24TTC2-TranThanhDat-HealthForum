<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_Slide.ascx.cs" Inherits="MyWebSite.Control.Default.My_U_Slide" %>
<script src="../../Scripts/contentslider.js"></script>
<div id="slider2" style="vertical-align:top">
<div id="paginate-slider2" class="pagination" style="text-align:left"><a href="#prev" class="prev">Quay lại</a> <a rel="1" href="#1" class="toc">1</a> <a rel="2" href="#2" class="toc">2</a> <a rel="3" href="#3" class="toc">3</a> <a rel="4" href="#4" class="toc">4</a> <a rel="5" href="#5" class="toc selected">5</a> <a rel="6" href="#6" class="toc">6</a> <a href="#next" class="next">Xem tiếp</a></div> 
<div class="sliderwrapper"> 
        <%-- <div style="display: block; z-index: 4; visibility: visible;" class="contentdiv">
         <div class="cat_image">
         <div class="imagesmain">
      <div class="images">
          <img  alt="" src="../../Images/slide5.jpg" />
      </div>    
      </div>
      <div class="sliderPostInfo">
                 <h2 class="feaSliderTitle">
                  <a rel="bookmark" href="le-hoi-xuan-hong-2013_d2873.aspx">Lễ Hội xuân hồng 2013</a>
                 </h2>
          </div>
      </div>
          <div style="clear: both"></div>
          <div class="featuredPost lastPost" style="margin:0px">
           <p style="vertical-align:bottom;">
           Phan tom tat</p>
          </div>
         </div>--%>
     <asp:Literal ID="ltView" runat="server"></asp:Literal>
               
</div>
</div>
<script type="text/javascript">
    featuredcontentslider.init({
        id: "slider2",  //id of main slider DIV
        contentsource: ["inline", ""],  //Valid values: ["inline", ""] or ["ajax", "path_to_file"]
        toc: "#increment",  //Valid values: "#increment", "markup", ["label1", "label2", etc]
        nextprev: ["Quay lại", "Xem tiếp"],  //labels for "prev" and "next" links. Set to "" to hide.
        revealtype: "click", //Behavior of pagination links to reveal the slides: "click" or "mouseover"
        enablefade: [true, 0.4],  //[true/false, fadedegree]
        autorotate: [true, 5000],  //[true/false, pausetime]
        onChange: function (previndex, curindex) {  //event handler fired whenever script changes slide
            //previndex holds index of last slide viewed b4 current (1=1st slide, 2nd=2nd etc)
            //curindex holds index of currently shown slide (1=1st slide, 2nd=2nd etc)
        }
    })
</script>