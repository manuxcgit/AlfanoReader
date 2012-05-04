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
import java.util.logging.Handler;
import java.util.logging.Logger;

import javax.naming.Context;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JProgressBar;
import javax.swing.JTable;

import com.sun.xml.internal.ws.api.message.Message;

import gnu.io.*;

import java.awt.Button;


public class classSerial implements SerialPortEventListener{
	
	private SerialPort _serialPort;
	private Handler _handleToOrigin;
	private InputStream _inputStream;
	private classParamSerial _paramSerial;
	private boolean _isInitialized = false;
	private static final int TIME_OUT = 2000;
	private String _appName;
	

	public classSerial(Handler h, String appName){
		_handleToOrigin = h;
		_appName = appName; 
		_paramSerial = new classParamSerial("COM3");
	}
	
	public boolean m_connect(){
		CommPortIdentifier portId = findPortId();
		if (!_isInitialized){
			return false;
		}
		try{
			 _serialPort = (SerialPort)portId.open(_appName, TIME_OUT);
	         _serialPort.setSerialPortParams(_paramSerial.data_rate,
	                                        _paramSerial.data_bits,
	                                        _paramSerial.stop_bits,
	                                        _paramSerial.parity_);
	        // output = serialPort.getOutputStream();
	         _serialPort.notifyOnDataAvailable(true);
	         _serialPort.addEventListener( this);
	         _inputStream = _serialPort.getInputStream();
	         return true;
		}
		catch (Exception e){ return false;}
	}
	
	
	public boolean IsInitialized() {
		return _isInitialized;
	}
	
	private class classParamSerial{
		int data_rate;
		int data_bits;
		int stop_bits;
		int parity_;
		String port_name;
		
		public classParamSerial(String portName,int rate, int bits, int stopbit, int par){
			data_rate = rate;
			data_bits = bits;
			stop_bits = stopbit;
			parity_ = par;
			port_name = portName;
		}
		
		public classParamSerial(String portName){
			data_rate = 9600;
			data_bits = SerialPort.DATABITS_8;
			stop_bits = SerialPort.STOPBITS_1;
			parity_ = SerialPort.PARITY_NONE;
			port_name = portName;
		}
	}
	
	private CommPortIdentifier findPortId() {
	    CommPortIdentifier portId = null;
	    Enumeration portEnum = CommPortIdentifier.getPortIdentifiers();
	    while (portEnum.hasMoreElements()) {
	        CommPortIdentifier currPortId = (CommPortIdentifier)portEnum.nextElement();
            if (currPortId.getName().equals(_paramSerial.port_name)) {
                portId = currPortId;
                break;
            }
	    }
	    _isInitialized=(portId!=null);
	    return portId;
	}
	
	public void serialEvent(SerialPortEvent event) {
		switch (event.getEventType()) {
			case SerialPortEvent.DATA_AVAILABLE:
				try {
					if (_inputStream.available() > 0) {
						try {
							
							
							Message info = new Message();
				        	info.arg1 = TOMAINFRAME_LOG_READY;
				        	ToMainFrame.sendMessage(info);
				        	
				        	_handleToOrigin.
	//log.debug("serialEvent: " + serialPort.getInputStream().available() + " bytes available");
	//			pBChargement.setValue(getInputStream().available());


							synchronized (this) {
								this.notify();                                   					
							}
						} 
						catch (Exception e) {
	//log.error("Error in handleSerialData method", e);161.
						}              
					} 
					else {
	//log.warn("We were notified of new data but available() is returning 0");
					}
				} 
				catch (IOException ex) {

	// it's best not to throw the exception because the RXTX thread may not be prepared to handle

	//log.error("RXTX error in serialEvent method", ex);
				}
			default:
	//log.debug("Ignoring serial port event type: " + event.getEventType());
		}    
	}
}
