import xml.dom.minidom

# Cria o documento
doc = xml.dom.minidom.Document()
# Cria os elementos
root = doc.createElement('tempo')
cidade = doc.createElement('cidade')
cidade.appendChild(doc.createTextNode('Presidente Prudente/SP'))
previsao = doc.createElement('previsao')
previsao.appendChild(doc.createTextNode('chuva'))

# Cria os atributos
root.setAttribute('min', '20')
root.setAttribute('max', '29')

# Cria a estrutura
doc.appendChild(root)
root.appendChild(cidade)
root.appendChild(previsao)

print (doc.toprettyxml()) # Mostra o XML formatado
doc.writexml(open("d:/teste.xml", 'w')) #salva em arquivo
