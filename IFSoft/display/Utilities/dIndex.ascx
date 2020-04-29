<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dIndex.ascx.cs" Inherits="IFSoft.display.Utilities.dIndex" %>
<%@ Register src="../Product/dProductMenu.ascx" tagname="dProductMenu" tagprefix="uc1" %>



<div class="header_slide">
			<div class="header_bottom_left">				
				<div class="categories">
				  <ul>
				  	<h3>Sản phẩm</h3>
				      <uc1:dProductMenu ID="dProductMenu1" runat="server" />
				  </ul>
				</div>					
	  	     </div>
					 <div class="header_bottom_right">					 
					 	 <div class="slider">					     
							 <div id="slider">
			                    <div id="mover">
			                    	<div id="slide-1" class="slide">			                    
									 <div class="slider-img">
									     <a href="preview.html"><img src="temp/images/slide-1-image.png" alt="learn more" /></a>									    
									  </div>
						             	<div class="slider-text">
		                                 <h1>Clearance<br><span>SALE</span></h1>
		                                 <h2>UPTo 20% OFF</h2>
									   <div class="features_list">
									   	<h4>Get to Know More About Our Memorable Services Lorem Ipsum is simply dummy text</h4>							               
							            </div>
							             <a href="preview.html" class="button">Shop Now</a>
					                   </div>			               
									  <div class="clear"></div>				
				                  </div>	
						             	<div class="slide">
						             		<div class="slider-text">
		                                 <h1>Clearance<br><span>SALE</span></h1>
		                                 <h2>UPTo 40% OFF</h2>
									   <div class="features_list">
									   	<h4>Get to Know More About Our Memorable Services</h4>							               
							            </div>
							             <a href="preview.html" class="button">Shop Now</a>
					                   </div>		
						             	 <div class="slider-img">
									     <a href="preview.html"><img src="temp/images/slide-3-image.jpg" alt="learn more" /></a>
									  </div>						             					                 
									  <div class="clear"></div>				
				                  </div>
				                  <div class="slide">						             	
					                  <div class="slider-img">
									     <a href="preview.html"><img src="temp/images/slide-2-image.jpg" alt="learn more" /></a>
									  </div>
									  <div class="slider-text">
		                                 <h1>Clearance<br><span>SALE</span></h1>
		                                 <h2>UPTo 10% OFF</h2>
									   <div class="features_list">
									   	<h4>Get to Know More About Our Memorable Services Lorem Ipsum is simply dummy text</h4>							               
							            </div>
							             <a href="preview.html" class="button">Shop Now</a>
					                   </div>	
									  <div class="clear"></div>				
				                  </div>												
			                 </div>		
		                </div>
					 <div class="clear"></div>					       
		         </div>
		      </div>
		   <div class="clear"></div>
		</div>
   </div>
		
 <div class="main">
    <div class="content">
    	<div class="content_top">
    		<div class="heading">
    		<h3>Sản phẩm mới</h3>
    		</div>
    		<div class="see">
    			<p><a href="#">Xem tất cả</a></p>
    		</div>
    		<div class="clear"></div>
    	</div>
	      <div class="section group">
			  <asp:Repeater ID="rptNewProduct" runat="server">
				  <ItemTemplate>
					  <div class="grid_1_of_4 images_1_of_4">
						<a href='?f=product&fs=des&id=<%#:Eval("ProDelID") %>'><img src="/Images/<%#:Eval("vImage") %>"/></a>
						<h2><%#:Eval("vName") %></h2>
						<div class="price-details">
							<div class="price-number">
								<p><span class="rupees"><%#:string.Format("{0:N0}", Eval("vPrice")) %></span></p>
							</div>
					       	<div class="add-cart">								
								<h4><a href="preview.html">Thêm vào giỏ</a></h4>
								</div>
							<div class="clear"></div>
						</div>
					</div>
				  </ItemTemplate>
			  </asp:Repeater>
				
			</div>
			<div class="content_bottom">
    		<div class="heading">
    		<h3>Giá sản phẩm</h3>
    		</div>
    		<div class="see">
    			<p><a href="#">Xem tất cả</a></p>
    		</div>
    		<div class="clear"></div>
    	</div>
			<div class="section group">
				<asp:Repeater ID="rptPriceProduct" runat="server">
				  <ItemTemplate>
					  <div class="grid_1_of_4 images_1_of_4">
						<a href='?f=product&fs=des&id=<%#:Eval("ProDelID") %>'><img src="/Images/<%#:Eval("vImage") %>"/></a>
						<h2><%#:Eval("vName") %></h2>
						<div class="price-details">
							<div class="price-number">
								<p><span class="rupees"><%#:string.Format("{0:N0}", Eval("vPrice")) %></span></p>
							</div>
					       	<div class="add-cart">								
								<h4><a href="preview.html">Thêm vào giỏ</a></h4>
								</div>
							<div class="clear"></div>
						</div>
					</div>
				  </ItemTemplate>
			  </asp:Repeater>
			</div>
    </div>
 </div>
</div>