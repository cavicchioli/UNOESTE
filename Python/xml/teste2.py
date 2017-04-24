import xml.dom.minidom

doc = xml.dom.minidom.parse("d:/teste.xml")

node=doc.getElementsByTagName("cidade")
print (node[0].firstChild.nodeValue)

node=doc.getElementsByTagName("tempo")
print (node[0].getAttribute('max'))
