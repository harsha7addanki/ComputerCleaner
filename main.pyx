from pathlib import Path
import tkinter as tk
import tkinter.ttk as ttk
from threading import Thread

templocation = f"{Path.home()}\\AppData\\Local\\Temp"


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
def deletetempfiles():
    status['text'] = f"discovering files..."
    p["mode"] = "indeterminate"
    root.update()
    import os
    files = []
    folders = []
    filecount = 1
    for (dirpath, dirnames, filenames) in os.walk(templocation):
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
        status['text'] = f"deleting {file} {i+1}/{total}"
        try:
            os.remove(f"{file}")
        except (PermissionError, FileNotFoundError):
            total -= 1
        p.step(1/total * 100)
        root.update()

    totalfolders = len(folders)

    p['value'] = 0
    for folder, i in zip(folders, range(totalfolders)):
        status['text'] = f"deleting folder {folder} {i+1}/{totalfolders}"
        try:
            os.rmdir(f"{folder}")
        except (PermissionError, FileNotFoundError, OSError):
            totalfolders -= 1
        p.step(1/totalfolders * 100)
        root.update()
    status['text'] = f"Finished!"
    p['value'] = 100

Thread(target=deletetempfiles).start()

root.mainloop()