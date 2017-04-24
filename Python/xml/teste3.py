from lxml import etree

xmlschema_doc = etree.parse('tempo.xsd')
xml_doc = etree.parse('tempo.xml')
xmlschema = etree.XMLSchema(xmlschema_doc)

if xmlschema.validate(xml_doc):
    print ('Valid xml')
else:
    print ('Invalid xml')
