import java.awt.EventQueue;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.util.Enumeration;
import java.util.logging.Logger;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JProgressBar;
import javax.swing.JTable;
import gnu.io.*;



public class AlfanoReader implements SerialPortEventListener {

	private JFrame frame;
	private JTable table;
	JProgressBar pBChargement = new JProgressBar();
	JButton btnAnnuler; 
	JLabel lblInfo;
	boolean chargerAlfanoRunning;
	
	
	 private static final String PORT_NAMES[] = {
	        "/dev/tty.usbserial-A9007UX1", // Mac OS X
	        "/dev/ttyUSB0", // Linux
	        "COM3", // Windows
	    };
	    private static final int TIME_OUT = 2000;
	    private static final int DATA_RATE = 9600;

	    private SerialPort serialPort;
	    private OutputStream output;
	    private ByteArrayOutputStream bout;
	    private OutputStreamWriter writer;
	    private InputStream inputStream;

	    //private final static Logger log = Logger.getLogger(AlfanoReader.class);
	
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					AlfanoReader window = new AlfanoReader();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public AlfanoReader() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		//frame.getContentPane().setVisible(false);
		frame.getContentPane().setBounds(new Rectangle(5, 5, 5, 5));
		frame.setBounds(100, 100, 643, 474);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		table = new JTable();
		table.setBounds(33, 87, 307, 201);
		frame.getContentPane().add(table);
		
		btnAnnuler = new JButton("Annuler");
		btnAnnuler.setBounds(new Rectangle(10, 10, 10, 10));
		btnAnnuler.setBounds(451, 87, 89, 34);
		btnAnnuler.setVisible(false);
		btnAnnuler.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				e_btnAnnulerClick();
			}
		});
		frame.getContentPane().add(btnAnnuler);
		
		pBChargement.setMaximum(2048);
		pBChargement.setBounds(30, 372, 310, 14);
		pBChargement.setVisible(false);
		frame.getContentPane().add(pBChargement);
		
		lblInfo = new JLabel("Info");
		lblInfo.setBounds(33, 341, 184, 14);
		lblInfo.setVisible(false);
		frame.getContentPane().add(lblInfo);
		
		
		JMenuBar menuBar = new JMenuBar();
		menuBar.setToolTipText("Test\r\nEssai");
		frame.setJMenuBar(menuBar);
		
		JMenu mnFichier = new JMenu("Fichier");
		menuBar.add(mnFichier);
		
		JMenuItem mntmOuvrir = new JMenuItem("Ouvrir");
		mnFichier.add(mntmOuvrir);
		
		JMenuItem mntmChargerDepuisAlfano = new JMenuItem("Charger depuis Alfano");
		mntmChargerDepuisAlfano.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				m_chargerDepuisAlfano();
			}

		});
		mnFichier.add(mntmChargerDepuisAlfano);
	}
	

	protected void e_btnAnnulerClick() {
		// TODO Auto-generated method stub
		chargerAlfanoRunning = false;
	}

	private void m_chargerDepuisAlfano() {
		pBChargement.setVisible(true);
		btnAnnuler.setVisible(true);
		lblInfo.setVisible(true);
		lblInfo.setText("En attente de chargement");
		 try {
			 CommPortIdentifier portId = findPortId();
		        if (portId == null) {
		            lblInfo.setText("Could not find COM port.");
		            return;
		        }
	            serialPort = (SerialPort)portId.open(this.getClass().getName(), TIME_OUT);
	            serialPort.setSerialPortParams(DATA_RATE,
	                                           SerialPort.DATABITS_8,
	                                           SerialPort.STOPBITS_1,
	                                           SerialPort.PARITY_NONE);
	            output = serialPort.getOutputStream();
	            serialPort.notifyOnDataAvailable(true);
	            serialPort.addEventListener( this);
	            inputStream = serialPort.getInputStream();
;
	            	
	            }
	        
	        catch (Exception e) {
	            
	        }					
		Thread chargerAlfano = new Thread(){
			public void run(){
				try {
					chargerAlfanoRunning = true;
					
			        try {
			            
			            while (chargerAlfanoRunning){
			            	Thread.sleep(100);
			            	
			            }
			        }
			        catch (Exception e) {
			            
			        }						
					
					
				} catch (Exception e) {
					// TODO: handle exception
					pBChargement.setValue(100);
				}
				pBChargement.setVisible(false);
				btnAnnuler.setVisible(false);
				lblInfo.setVisible(false);
			}
		};
		chargerAlfano.start();
	}
	
private CommPortIdentifier findPortId() {
    CommPortIdentifier portId = null;
    Enumeration portEnum = CommPortIdentifier.getPortIdentifiers();
    while (portEnum.hasMoreElements()) {
        CommPortIdentifier currPortId = (CommPortIdentifier)portEnum.nextElement();
        for (String portName : PORT_NAMES) {
            if (currPortId.getName().equals(portName)) {
                portId = currPortId;
                break;
            }
        }
    }
    return portId;
}

public InputStream getInputStream() {

return inputStream;

}

 

public void serialEvent(SerialPortEvent event) {

	switch (event.getEventType()) {

		case SerialPortEvent.DATA_AVAILABLE:

 

					try {

						if (this.getInputStream().available() > 0) {

try {

//log.debug("serialEvent: " + serialPort.getInputStream().available() + " bytes available");
			pBChargement.setValue(getInputStream().available());


synchronized (this) {
this.notify();                                     

}

} catch (Exception e) {

//log.error("Error in handleSerialData method", e);161.
}              

} else {

//log.warn("We were notified of new data but available() is returning 0");

}

} catch (IOException ex) {

// it's best not to throw the exception because the RXTX thread may not be prepared to handle

//log.error("RXTX error in serialEvent method", ex);

}

default:

//log.debug("Ignoring serial port event type: " + event.getEventType());

}      

}
}
