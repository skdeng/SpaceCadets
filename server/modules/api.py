import json
import psycopg2
from flask import Flask, request, redirect, url_for, send_from_directory,jsonify
from werkzeug import secure_filename

app = Flask(__name__)
app.debug = True


#Test Route
@app.route('/')
def hello_world():
    return 'Hello World!'

#Get the information of a user
@app.route('/getUserInfo', methods=['GET'])
def getUserInfo():
  username = request.args.get('username')
  cur = connectToDatabase()
  try:
	cur.execute("""SELECT * FROM Users WHERE UserName = '"""+username+"""';""")
	rows = cur.fetchall()
	print rows[0]
  except:
 	print "I can't drop our test database!"
  table = {}
  table["username"] = rows[0][0];
  table["positionx"] = rows[0][1];
  table["positiony"] = rows[0][2];
  table["positionz"] = rows[0][3];
  table["currentHealth"] = rows[0][4];
  table["inventoryItems"] = rows[0][5];
  
  return jsonify(table)

def connectToDatabase():
  username = request.args.get('username')
  param = "dbname='cs421' user='cs421g07' host='comp421.cs.mcgill.ca' port='5432' password='421isdaBOMB'"
  try:
    conn = psycopg2.connect(param)
  except Exception, e:
    print e
    print "I am unable to connect to the database"
    print param

  cur = conn.cursor()
  return cur

if __name__ == '__main__':
  app.run(host='0.0.0.0')
