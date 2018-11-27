<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="True" Inherits="daikon.login" %>

<!--#include file="includes/header.inc" -->
		<!--end header-->
		<table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 761px">
			<tbody>
				<tr>
					<td class="leftnav" valign="top" width="159" style="height: 700px"><!--left side bar-->
						<table border="0" cellpadding="0" cellspacing="0" width="159">
							<tbody>
								<tr>
									<td colspan="2">
									</td>
								</tr>
								<tr>
									<td width="10">
									</td>
									<td class="leftnav">
									</td>
								</tr>
								
								<tr><form action="#">
                                    <TD width="12"></TD>
                                    <td class="leftnav"></td>
                                    </form>
                                </tr>
								
								<tr>
									<td colspan="2"></td>
								</tr>
								<tr>
									<td width="12"></td>
								</tr>
								<tr>
									<td colspan="2" style="height: 16px"></td>
								</tr>								
								<tr>
									<td width="12" style="height: 38px"></td>
									<td class="leftnav" style="height: 38px">
									</td>
								</tr>
								<tr>
									<td colspan="2" style="height: 20px"></td>
								</tr>
								<tr>
									<td width="12"></td>
									<td class="leftnav">
									</td>
								</tr>
								<tr>
									<td colspan="2"></td>
								</tr>
								<tr>
									<td width="12"></td>
									<td class="leftnav">
										</td>
								</tr>
								<tr>
									<td colspan="2"></td>
								</tr>
								<tr>
									<td width="12"></td>
									<td class="leftnav">
                                </td>
								</tr>
							</tbody>
						</table>
						<!--end left side bar-->
                        <!--<asp:Image ID="Image1" runat="server" border="0" Height="175px" ImageUrl="~/images/troika_175.gif"
                            Width="161px" /> -->                           
                          
					<td class="copy" style="height: 700px">
						<p class="pagetitle">MySARE<br />SARE Grant Reporting System</p>
						<p>
                            Grant recipients are required to register with the MySARE reporting system. MySARE is separate from the online grant application system(s). Grant recipients must register for each system independently. Registered users may log in below to submit a SARE project report.
                        </p>
                        <!-- 
                        <p>
                            It is no longer necessary to log into MySARE to enter calendar events. Please visit the calendar to <a href="http://www.sare.org/Events/Event-Calendar">submit new events.</a>
                        </p>
                        -->
                        <script language="JavaScript">
	                        $(document).ready(function(){
	                            $('#txtUserName').focus();
                                $('#txtUserName').select();
	                        });
	                    </script>



						<form id="daikonLogin" method="post" runat="server">
							<table border="0" cellspacing="0" cellpadding="4">
								<tr>
									<td>Username</td>
									<td>&#160;&#160;&#160;<input id="txtUserName" type="text" runat="server" NAME="txtUserName" size="20" class="userpass"></td>
									<td>
                                        </td>
								</tr>
								<tr>
									<td style="height: 32px">Password</td>
									<td style="height: 32px">&#160;&#160;&#160;<input id="txtUserPass" type="password" runat="server" NAME="txtUserPass" size="20" class="userpass"></td>
									<td style="height: 32px">
                                        </td>
								</tr>
								<tr>
									<td></td>
									<td></td>
									<td></td>
								</tr>
								<tr>
									<td>
										<input type="submit" Value="Log In" runat="server" ID="cmdLogin" NAME="cmdLogin" onserverclick="cmdLogin_ServerClick">
									</td>
									<td colspan="2"><asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" /></td>
								</tr>
							</table>
							<br>
							<a href="lostPassword.aspx">Retrieve lost password or username</a><br>
							<br>
                            New User? Please
                            <!-- <INPUT id="cmdRegister" type="submit" value="Register" name="cmdRegister" runat="server" onserverclick="cmdRegister_ServerClick">.<br> -->
                            <input type=button onClick="location.href = 'newuser.aspx'" value='Register'>.<br>
							<br>
							<br>
						</form>
					</td>
				</tr>
				<!--#include file="includes/footer.inc" -->
			</tbody>
		</table>
	</body>
</HTML>
