package appnotepad;

import java.io.*;
import javax.swing.JFileChooser;
import javax.swing.text.BadLocationException;

public class FrameEditor extends javax.swing.JFrame {

    private JFileChooser fc = null;
    
    public FrameEditor() {
        initComponents();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        pBotoes = new javax.swing.JPanel();
        bNovo = new javax.swing.JButton();
        bAbrir = new javax.swing.JButton();
        bSalvar = new javax.swing.JButton();
        bSair = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        taTexto = new javax.swing.JTextArea();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        bNovo.setLabel("Novo");
        bNovo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bNovoActionPerformed(evt);
            }
        });
        pBotoes.add(bNovo);
        bNovo.getAccessibleContext().setAccessibleName("Novo");

        bAbrir.setText("Abrir");
        bAbrir.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bAbrirActionPerformed(evt);
            }
        });
        pBotoes.add(bAbrir);

        bSalvar.setText("Salvar");
        bSalvar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bSalvarActionPerformed(evt);
            }
        });
        pBotoes.add(bSalvar);

        bSair.setText("Sair");
        bSair.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bSairActionPerformed(evt);
            }
        });
        pBotoes.add(bSair);

        getContentPane().add(pBotoes, java.awt.BorderLayout.PAGE_END);

        taTexto.setColumns(20);
        taTexto.setRows(5);
        jScrollPane1.setViewportView(taTexto);

        getContentPane().add(jScrollPane1, java.awt.BorderLayout.CENTER);

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void bNovoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bNovoActionPerformed
        if (fc.getSelectedFile() != null)
        {
            fc = null;
        }
        taTexto.setText("");
    }//GEN-LAST:event_bNovoActionPerformed

    private void bSalvarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bSalvarActionPerformed
        RandomAccessFile arq = null;
        if (fc == null)
        {
            fc = new JFileChooser();
            fc.showSaveDialog(this);
        }
        if (fc.getSelectedFile() != null)
        {
            try
            {
                arq = new RandomAccessFile(((File)fc.getSelectedFile()).getAbsolutePath(), "rw");
                arq.writeBytes(taTexto.getText().replace("\r\n", "#13"));
                arq.close();
            }catch(IOException ex){}
        }
    }//GEN-LAST:event_bSalvarActionPerformed

    private void bSairActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bSairActionPerformed
        dispose();
    }//GEN-LAST:event_bSairActionPerformed

    private void bAbrirActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bAbrirActionPerformed
        fc = new JFileChooser();
        fc.showOpenDialog(this);
        if (fc.getSelectedFile() != null)
        {
            try
            {
                RandomAccessFile arq = new RandomAccessFile(((File)fc.getSelectedFile()).getAbsolutePath(), "r");
                while(arq.getFilePointer() != arq.length())
                {
                    taTexto.append(arq.readLine()+"\r\n");
                }
                try {
                    taTexto.setText(taTexto.getText(0, taTexto.getText().length()-1));
                } catch (BadLocationException ex) {}
                arq.close();
            }catch(IOException ex){}
        }
    }//GEN-LAST:event_bAbrirActionPerformed

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton bAbrir;
    private javax.swing.JButton bNovo;
    private javax.swing.JButton bSair;
    private javax.swing.JButton bSalvar;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JPanel pBotoes;
    private javax.swing.JTextArea taTexto;
    // End of variables declaration//GEN-END:variables
}
