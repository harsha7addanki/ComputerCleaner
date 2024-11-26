from pathlib import Path
import tkinter as tk
from tkinter.messagebox import askyesno
import tkinter.ttk as ttk
from threading import Thread



root = tk.Tk()
root.title("Cleaner")
root.geometry("700x100")
root.resizable(False, False)
status =  ttk.Label(root, text="waiting to start...")
status.pack()
p = ttk.Progressbar(root, orient="horizontal", length=700, mode="indeterminate",
                    takefocus=True, maximum=100)
p.pack()

p['value'] = 0

def updateRoot():
    while True:
        root.update()

def deletetempfiles():
    import os
    affectAllUsers = askyesno("Users affected", f"Do you want to delete the temporary files of all all users?\n The current user is {os.getlogin()}")        
    status['text'] = f"discovering files..."
    templocations = [
        f"{Path.home()}\\AppData\\Local\\Temp"
    ]
    if affectAllUsers:
        for user in os.listdir("C:\\Users"):
            templocations.append(f"C:\\Users\\{user}\\AppData\\Local\\Temp")

    p["mode"] = "indeterminate"
    root.update()
    files = []
    folders = []
    filecount = 1
    for location in templocations:
        for (dirpath, dirnames, filenames) in os.walk(location):
            for dirname in dirnames:
                folders.append(os.path.join(dirpath, dirname))
            for filename in filenames:
                status['text'] = f"discovering {filecount} files..."
                files.append(os.path.join(dirpath, filename))
                root.update()
                filecount += 1


    total = len(files)
    del filecount

    
    p["mode"] = "determinate"
    root.update()
    for file, i in zip(files, range(total)):
        status['text'] = f"deleting {file}\n{i+1}/{total}"
        try:
            os.remove(f"{file}")
        except (PermissionError, FileNotFoundError):
            total -= 1
        p.step(1/total * 100)
        root.update()

    totalfolders = len(folders)

    p['value'] = 0
    for folder, i in zip(folders, range(totalfolders)):
        status['text'] = f"deleting folder {folder}\n{i+1}/{totalfolders}"
        try:
            os.rmdir(f"{folder}")
        except (PermissionError, FileNotFoundError, OSError):
            totalfolders -= 1
        p.step(1/totalfolders * 100)
        root.update()
    status['text'] = f"Finished!"
    p['value'] = 100

Thread(target=deletetempfiles).start()
Thread(target=updateRoot).start()

root.mainloop()