from pathlib import Path
from threading import Thread

cdef void start(status, progressbar, int affectAllUsers):
    def runFileRemover():
        status.pack()    
        progressbar.pack()

        import os
        status['text'] = f"discovering files..."
        templocations = [
            f"{Path.home()}\\AppData\\Local\\Temp",
            "C:\\Windows\\Temp"
        ]
        if affectAllUsers == 1:
            for user in os.listdir("C:\\Users"):
                templocations.append(f"C:\\Users\\{user}\\AppData\\Local\\Temp")

        progressbar.configure(mode="indeterminate")
        progressbar.start()
        files = []
        folders = []
        filecount = 1
        for location in templocations:
            for (dirpath, dirnames, filenames) in os.walk(location):
                for dirname in dirnames:
                    folders.append(os.path.join(dirpath, dirname))
                for filename in filenames:
                    status.configure(text=f"discovering {filecount} files...")
                    files.append(os.path.join(dirpath, filename))
                    filecount += 1


        total = len(files)
        del filecount

        progressbar.stop()

        
        progressbar.configure(mode="determinate")
        for file, i in zip(files, range(total)):
            status.configure(text=f"deleting {file}\n{i+1}/{total}")
            try:
                os.remove(f"{file}")
            except (PermissionError, FileNotFoundError):
                total -= 1
            progressbar.set(1/total * 100)

        totalfolders = len(folders)

        progressbar.set(0)
        for folder, i in zip(folders, range(totalfolders)):
            status.configure(text=f"deleting folder {folder}\n{i+1}/{totalfolders}")
            try:
                os.rmdir(f"{folder}")
            except (PermissionError, FileNotFoundError, OSError):
                totalfolders -= 1
            progressbar.set(1/totalfolders * 100)
        status.configure(text="Finished!")
        progressbar.set(100)
    thread = Thread(target=runFileRemover)
    thread.setDaemon(True)
    thread.start()
