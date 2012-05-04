import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JLabel;
import java.awt.BorderLayout;
import javax.swing.JSpinner;
import javax.swing.JComboBox;
import java.awt.Frame;
import java.awt.Window.Type;
import javax.swing.JSeparator;
import javax.swing.JButton;

import gnu.*;
import gnu.io.SerialPort;


public class frameParamSerial {

	private JFrame frmParamtresPortSrie;
	private SerialPort serialInfo;

	/**
	 * Launch the application.
	 */
/*	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					frameParamSerial window = new frameParamSerial();
					window.frmParamtresPortSrie.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}*/

	/**
	 * Create the application.
	 */
	public frameParamSerial() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frmParamtresPortSrie = new JFrame();
		frmParamtresPortSrie.setType(Type.UTILITY);
		frmParamtresPortSrie.setResizable(false);
		frmParamtresPortSrie.setTitle("Param\u00E8tres Port S\u00E9rie");
		frmParamtresPortSrie.setBounds(100, 100, 246, 225);
		frmParamtresPortSrie.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frmParamtresPortSrie.getContentPane().setLayout(null);
		
		JLabel lblNewLabel = new JLabel("Port :");
		lblNewLabel.setBounds(10, 15, 70, 14);
		frmParamtresPortSrie.getContentPane().add(lblNewLabel);
		
		JLabel lblBauds = new JLabel("Bauds :");
		lblBauds.setBounds(10, 42, 46, 14);
		frmParamtresPortSrie.getContentPane().add(lblBauds);
		
		JLabel lblParit = new JLabel("Parit\u00E9 :");
		lblParit.setBounds(10, 67, 46, 14);
		frmParamtresPortSrie.getContentPane().add(lblParit);
		
		JLabel lblStopBit = new JLabel("Stop Bit :");
		lblStopBit.setBounds(10, 91, 46, 14);
		frmParamtresPortSrie.getContentPane().add(lblStopBit);
		
		JLabel lblNewLabel_1 = new JLabel("Nbr Bits :");
		lblNewLabel_1.setBounds(10, 119, 46, 14);
		frmParamtresPortSrie.getContentPane().add(lblNewLabel_1);
		
		JComboBox comboBoxPortName = new JComboBox();
		comboBoxPortName.setBounds(66, 12, 164, 20);
		frmParamtresPortSrie.getContentPane().add(comboBoxPortName);
		
		JComboBox comboBox = new JComboBox();
		comboBox.setBounds(66, 38, 164, 20);
		frmParamtresPortSrie.getContentPane().add(comboBox);
		
		JComboBox comboBox_1 = new JComboBox();
		comboBox_1.setBounds(66, 64, 164, 20);
		frmParamtresPortSrie.getContentPane().add(comboBox_1);
		
		JComboBox comboBox_2 = new JComboBox();
		comboBox_2.setBounds(66, 90, 164, 20);
		frmParamtresPortSrie.getContentPane().add(comboBox_2);
		
		JComboBox comboBox_3 = new JComboBox();
		comboBox_3.setBounds(66, 116, 164, 20);
		frmParamtresPortSrie.getContentPane().add(comboBox_3);
		
		JSeparator separator = new JSeparator();
		separator.setBounds(0, 150, 240, 2);
		frmParamtresPortSrie.getContentPane().add(separator);
		
		JButton btnValider = new JButton("Valider");
		btnValider.setBounds(10, 163, 89, 23);
		frmParamtresPortSrie.getContentPane().add(btnValider);
		
		JButton btnAnnuler = new JButton("Annuler");
		btnAnnuler.setBounds(141, 163, 89, 23);
		frmParamtresPortSrie.getContentPane().add(btnAnnuler);
	}
}
