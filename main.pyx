from customtkinter import *
cimport tempfilecleaner

app = CTk()

# Top Elements
CTkLabel(master=app, text="Computer Cleaner", font=CTkFont(size=50, weight="bold")).pack(pady=20, padx=10)
tabview = CTkTabview(master=app)
tabview.pack(expand=True, fill="both")

# Tabs
tct = tabview.add("Temporary Cleaner")
tab2 = tabview.add("tab 2")

# First Tab
status = CTkLabel(master=tct, text="")

progressbar1 = CTkProgressBar(tct, orientation="horizontal")
progressbar1.configure(mode="indeterminate")

CTkLabel(master=tct, text="Temporary Files Cleaner").pack(pady=20, padx=10)

def startTempFilesClean():
    tempfilecleaner.start(status, progressbar1, cleanAllUsers)

button = CTkButton(master=tct, text="Start", corner_radius=25, command=startTempFilesClean)
button.pack(padx=20, pady=20)

cdef int cleanAllUsers
def checkbox_event():
    if checkbox.get() == 1:
        cleanAllUsers = 0
    else:
        cleanAllUsers = 1
checkbox = CTkCheckBox(tct, text="Clean for all users", command=checkbox_event)
checkbox.pack()
status.pack(pady=20, padx=10)
progressbar1.pack(pady=20, padx=10)
progressbar1.start()


status.pack_forget()
progressbar1.pack_forget()

# Tab 2
CTkLabel(master=tab2, text="Another Computer Optimizer").pack(pady=20, padx=10)
button2 = CTkButton(master=tab2, text="Start", corner_radius=25)
button2.pack(padx=20, pady=20)

app.mainloop()