import json
import psycopg2
import random
import string
import time
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
  connections = connectToDatabase()
  conn = connections[0]
  cur = connections[1]
  try:
	cur.execute("""SELECT * FROM Users WHERE UserName = '"""+username+"""';""")
	rows = cur.fetchall()
	print rows[0]
  except:
 	print "I can't get user info!"
  table = {}
  table["username"] = rows[0][0];
  table["positionx"] = rows[0][1];
  table["positiony"] = rows[0][2];
  table["positionz"] = rows[0][3];
  table["currentHealth"] = rows[0][4];
  table["inventoryItems"] = rows[0][5];
  table["progress"] = rows[0][6];
  
  cur.close()
  conn.close()
  return jsonify(table)

#put an item up for auction
@app.route('/addToAuction', methods=['GET'])
def addToAuction():
  username = request.args.get('username')
  itemId = request.args.get('itemId')
  connections = connectToDatabase()
  conn = connections[0]
  cur = connections[1]
  print """INSERT INTO AuctionHouse Values ('"""+id_generator()+"""', '"""+username+"""','"""+(time.strftime("%Y-%m-%d"))+"""', '"""+itemId+"""');"""

  try:
	cur.execute("""INSERT INTO AuctionHouse Values ('"""+id_generator()+"""', '"""+username+"""','"""+(time.strftime("%Y-%m-%d"))+"""', '"""+itemId+"""');""")
  	conn.commit()
  	return "Item successfully added to AuctionHouse"
  except:
 	return "Error inserting value to auctionhouse"
  cur.close()
  conn.close()

#put an bid to item to an auction
@app.route('/addBid', methods=['GET'])
def addToBid():
  auctionId = request.args.get('auctionId')
  itemsTrade = request.args.get('itemsToTrade')
  buyerName = request.args.get('buyerName')
  connections = connectToDatabase()
  conn = connections[0]
  cur = connections[1]
  print """INSERT INTO Bid Values ('"""+auctionId+"""', '"""+itemsTrade+"""','"""+buyerName+"""');"""

  try:
	cur.execute("""INSERT INTO Bid Values ('"""+auctionId+"""', '"""+itemsTrade+"""','"""+buyerName+"""');""")
  	conn.commit()
  	return "Item successfully added to Bid"
  except:
 	return "Error inserting value to Bid"
  cur.close()
  conn.close()
#Get all the auctions
@app.route('/getAllAuctions', methods=['GET'])
def getAllAuctions():
  connections = connectToDatabase()
  conn = connections[0]
  cur = connections[1]
  try:
	cur.execute("""SELECT * FROM AuctionHouse;""")
	rows = cur.fetchall()
  except:
 	print "I can't get auction info!"
  output = {}
  table = []
  for num in range (0, len(rows)-1):
    bid = {}
    bid["auctionid"] = rows[num][0]
    bid["sellername"] = rows[num][1]
    bid["itemid"] = rows[num][3]
    table.append(bid)
  output["bids"] = table
  print len(rows)

  cur.close()
  conn.close()
  return jsonify(output)
@app.route('/updatePlayer', methods=['GET'])
#Get all the bids of an auction
@app.route('/getAllBids', methods=['GET'])
def getAllBids():
  auctionId = request.args.get('auctionId')
  connections = connectToDatabase()
  conn = connections[0]
  cur = connections[1]
  try:
	cur.execute("""SELECT * FROM Bid WHERE auctionId = '"""+auctionId+"""';""")
	rows = cur.fetchall()
  except:
 	print "I can't get user info!"
  output = {}
  table = []
  for num in range (0, len(rows)-1):
    bid = {}
    bid["auctionId"] = rows[num][0]
    bid["buyerName"] = rows[num][2]
    bid["itemsToTrade"] = rows[num][1]
    table.append(bid)
  output["bids"] = table
  print len(rows)

  cur.close()
  conn.close()
  return jsonify(output)
@app.route('/updatePlayer', methods=['GET'])
def updatePlayer():
  username = request.args.get('username')
  positionx = request.args.get('positionx')
  positiony = request.args.get('positiony')
  positionz = request.args.get('positionz')
  health = request.args.get('health')
  inventory = request.args.get('inventory')
  progress = request.args.get('progess')
  connections = connectToDatabase()
  conn = connections[0]
  cur = connections[1]
  try:
  	print """UPDATE Users SET UserName = '"""+username+"""', PositionX = '"""+positionx+"""', PositionY = '"""+positiony+"""', PositionZ = '"""+positionz+"""', CurrentHealth = """+health+""", InventoryItems = '"""+inventory+"""';"""
	cur.execute("""UPDATE Users SET UserName = '"""+username+"""', PositionX = '"""+positionx+"""', PositionY = '"""+positiony+"""', PositionZ = '"""+positionz+"""', CurrentHealth = """+health+""", InventoryItems = '"""+inventory+"""', Progress ="""+progress+""";""")
  	conn.commit()          
  	return 'success'
  except:
 	print "I can't get user info!"

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
  return [conn,cur]

def id_generator(size=10, chars=string.ascii_uppercase + string.digits):
  return ''.join(random.choice(chars) for _ in range(size))
if __name__ == '__main__':
  app.run(host='0.0.0.0')
