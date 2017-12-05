import java.awt.*; 
import java.awt.event.*; 
import javax.swing.*; 
import java.sql.*;

public class Student{
	
	JFrame frame;
	Container cont;
	
    private JLabel headerOne;
    private JLabel idLabel;
    private JLabel addressLabel;
    private JLabel nameLabel;
    private JLabel progLabel;
    private JTextField idTxt;
    private JTextField addTxt;
    private JTextField nameTxt;
    private JTextField proTxt;
    private JButton addBtn;
    private JLabel headerTwo;
    private JLabel searchLabel;
    private JLabel idL;
    private JLabel nameL;
    private JLabel addressL;
    private JLabel progL;
    private JTextField sId;
    private JTextField idT;
    private JTextField nameT;
    private JTextField addT;
    private JTextField proT;
    private JButton searchBtn;
	
	public Student(){
		initGUI();
	}
	
	
	public void initGUI(){
		
		frame = new JFrame("Assignment No.2 BC000000");
		ButtonHandler bHandler = new ButtonHandler();
		
		headerOne = new JLabel ("Add new Records in Database");
		headerOne.setForeground (Color.blue);
        idLabel = new JLabel ("Enter ID:");
        addressLabel = new JLabel ("Enter address:");
        nameLabel = new JLabel ("Enter Name:");
        progLabel = new JLabel ("Enter Program:");
        idTxt = new JTextField (5);
        addTxt = new JTextField (5);
        nameTxt = new JTextField (5);
        proTxt = new JTextField (5);
        addBtn = new JButton ("Add Record in Database");
		searchBtn = new JButton ("Search Record From Database");
        headerTwo = new JLabel ("Search Record From Database");
		headerTwo.setForeground (Color.blue);
        searchLabel = new JLabel ("Enter ID:");
        idL = new JLabel ("ID:");
        nameL = new JLabel ("Name:");
        addressL = new JLabel ("address:");
        progL = new JLabel ("Program:");
        sId = new JTextField (5);
        idT = new JTextField (5);
		idT.setEditable(false);
        nameT = new JTextField (5);
		nameT.setEditable(false);
        addT = new JTextField (5);
		addT.setEditable(false);
        proT = new JTextField (5);
		proT.setEditable(false);
        
		
		headerOne.setBounds (30, 15, 185, 25);
        idLabel.setBounds (30, 60, 55, 20);
        addressLabel.setBounds (30, 90, 100, 20);
        nameLabel.setBounds (350, 55, 75, 20);
        progLabel.setBounds (350, 90, 100, 20);
        idTxt.setBounds (140, 55, 190, 25);
        addTxt.setBounds (140, 85, 190, 25);
        nameTxt.setBounds (460, 55, 210, 25);
        proTxt.setBounds (460, 85, 210, 25);
        addBtn.setBounds (30, 140, 280, 25);
		addBtn.addActionListener(bHandler);
        headerTwo.setBounds (25, 185, 185, 25);
        searchLabel.setBounds (30, 225, 60, 20);
        idL.setBounds (30, 260, 35, 20);
        nameL.setBounds (30, 295, 45, 20);
        addressL.setBounds (30, 330, 60, 20);
        progL.setBounds (30, 365, 70, 20);
        sId.setBounds (115, 220, 100, 25);
        idT.setBounds (115, 255, 205, 25);
        nameT.setBounds (115, 290, 205, 25);
        addT.setBounds (115, 325, 205, 25);
        proT.setBounds (115, 360, 205, 25);
        searchBtn.setBounds (240, 215, 225, 25);
		
		searchBtn.addActionListener(bHandler);
		
		cont = frame.getContentPane();
		cont.setLayout(null);
		
		cont.add (headerOne);
        cont.add (idLabel);
        cont.add (addressLabel);
        cont.add (nameLabel);
        cont.add (progLabel);
        cont.add (idTxt);
        cont.add (addTxt);
        cont.add (nameTxt);
        cont.add (proTxt);
        cont.add (addBtn);
        cont.add (headerTwo);
        cont.add (searchLabel);
        cont.add (idL);
        cont.add (nameL);
        cont.add (addressL);
        cont.add (progL);
        cont.add (sId);
        cont.add (idT);
        cont.add (nameT);
        cont.add (addT);
        cont.add (proT);
        cont.add (searchBtn);
		
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 
        frame.setSize(710, 470);	
        frame.setVisible(true); 
		
		
	}
//--------------------------------------------------------------------------------------------------------------------------

	private class ButtonHandler implements ActionListener {
		 public void actionPerformed(ActionEvent event) {
			 
				int id;
				String name,program,address;
				
			if (event.getSource() == addBtn) { 
			  
				id = Integer.parseInt(idTxt.getText());
				name = nameTxt.getText();
				program =  proTxt.getText();
				address = addTxt.getText();
				
				try{
					inseartDataInDB(id,name,program,address);
				}
				catch(SQLException e){
					System.out.println("Error: "+e);
				}
			
			 }
			 
			 if (event.getSource() == searchBtn) { 
			    
				int stdId = Integer.parseInt(sId.getText());
				
				try{

					getDataFromDB(stdId);
				}
				catch(SQLException e){
					System.out.println("Error: "+e);
				}
				
			 }
		 }
	}

//--------------------------------------------------------------------------------------------------------------------------	
	
	private void getDataFromDB(int stdId)throws SQLException{
		try{

     	Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
     	Connection con = DriverManager.getConnection("jdbc:ucanaccess://F:/CS506/BC0000000.accdb");
        Statement st = con.createStatement();
        String sql = "SELECT * FROM STUDENT WHERE ID = "+stdId+"";
        ResultSet rs = st.executeQuery(sql);
		
		if(!rs.isBeforeFirst()){
			JOptionPane.showMessageDialog(null, "No such record is available"); 
			idT.setText("");
			nameT.setText("");
			addT.setText("");
			proT.setText("");
		}else{
		int id=0;
		String name="",program="",address="";
		
        while(rs.next()){

		id = rs.getInt("ID");
		name = rs.getString("NAME");
		program = rs.getString("PROGRAM");
		address = rs.getString("ADDRESS");
		
        }
		
		idT.setText(String.valueOf(id));
        nameT.setText(name);
        addT.setText(address);
        proT.setText(program);
		}
     }catch(ClassNotFoundException e){
     	System.out.println("Error: "+e);
     }
	}
//--------------------------------------------------------------------------------------------------------------------------

	private void inseartDataInDB(int id,String name,String program,String address)throws SQLException{
		try{

     	Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
     	Connection con = DriverManager.getConnection("jdbc:ucanaccess://F:/CS506/BC0000000.accdb");
        Statement st = con.createStatement();
        String sql = "INSERT INTO STUDENT(ID,NAME,PROGRAM,ADDRESS) VALUES ("+id+",'"+name+"','"+program+"','"+address+"')";
        int result = st.executeUpdate(sql);

		if(result == 1){
			JOptionPane.showMessageDialog(null, "Data Inserted Successfully!"); 
		}
		
     }catch(ClassNotFoundException e){
     	System.out.println("Error: "+e);
     }
	}
	
//--------------------------------------------------------------------------------------------------------------------------	
	
	
	 public static void main(String args[]) { 

      Student Student = new Student(); 

 } 
	
	
}