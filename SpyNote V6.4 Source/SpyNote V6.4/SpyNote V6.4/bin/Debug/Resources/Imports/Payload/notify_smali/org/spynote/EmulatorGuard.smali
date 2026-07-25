.class public Lorg/spynote/EmulatorGuard;
.super Ljava/lang/Object;
.source "EmulatorGuard.java"


.method public static exitIfEmulator()V
    .locals 1

    :try_start_0
    invoke-static {}, Lorg/spynote/EmulatorGuard;->isEmulator()Z
    move-result v0
    if-eqz v0, :cond_0
    const/16 v0, 0xa
    invoke-static {v0}, Ljava/lang/System;->exit(I)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    :cond_0
    return-void
.end method

.method private static addScore(Ljava/lang/String;Ljava/lang/String;I)I
    .locals 1
    if-eqz p0, :ret
    invoke-virtual {p0}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;
    move-result-object p0
    invoke-virtual {p1}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;
    move-result-object p1
    invoke-virtual {p0, p1}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z
    move-result v0
    if-eqz v0, :ret
    add-int/lit8 p2, p2, 0x2
    :ret
    return p2
.end method

.method private static addScoreExact(Ljava/lang/String;Ljava/lang/String;I)I
    .locals 1
    if-eqz p0, :ret
    invoke-virtual {p0}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;
    move-result-object p0
    invoke-virtual {p1}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;
    move-result-object p1
    invoke-virtual {p0, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z
    move-result v0
    if-eqz v0, :ret
    add-int/lit8 p2, p2, 0x3
    :ret
    return p2
.end method

.method private static fileExists(Ljava/lang/String;)Z
    .locals 2
    :try_start_0
    new-instance v0, Ljava/io/File;
    invoke-direct {v0, p0}, Ljava/io/File;-><init>(Ljava/lang/String;)V
    invoke-virtual {v0}, Ljava/io/File;->exists()Z
    move-result v0
    return v0
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    :catch_0
    const/4 v0, 0x0
    return v0
.end method

.method private static isHardEmulator()Z
    .locals 1
    const-string v0, "/dev/qemu_pipe"
    invoke-static {v0}, Lorg/spynote/EmulatorGuard;->fileExists(Ljava/lang/String;)Z
    move-result v0
    if-eqz v0, :c1
    const/4 v0, 0x1
    return v0
    :c1
    const-string v0, "/dev/socket/qemud"
    invoke-static {v0}, Lorg/spynote/EmulatorGuard;->fileExists(Ljava/lang/String;)Z
    move-result v0
    if-eqz v0, :c2
    const/4 v0, 0x1
    return v0
    :c2
    const-string v0, "/system/lib/libc_malloc_debug_qemu.so"
    invoke-static {v0}, Lorg/spynote/EmulatorGuard;->fileExists(Ljava/lang/String;)Z
    move-result v0
    if-eqz v0, :c3
    const/4 v0, 0x1
    return v0
    :c3
    const-string v0, "/sys/qemu_trace"
    invoke-static {v0}, Lorg/spynote/EmulatorGuard;->fileExists(Ljava/lang/String;)Z
    move-result v0
    return v0
.end method

.method private static isEmulator()Z
    .locals 3

    invoke-static {}, Lorg/spynote/EmulatorGuard;->isHardEmulator()Z
    move-result v0
    if-eqz v0, :score
    const/4 v0, 0x1
    return v0

    :score
    const/4 v0, 0x0

    sget-object v1, Landroid/os/Build;->HARDWARE:Ljava/lang/String;
    const-string v2, "goldfish"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScoreExact(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->HARDWARE:Ljava/lang/String;
    const-string v2, "ranchu"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScoreExact(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->HARDWARE:Ljava/lang/String;
    const-string v2, "vbox"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->HARDWARE:Ljava/lang/String;
    const-string v2, "nox"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0

    sget-object v1, Landroid/os/Build;->FINGERPRINT:Ljava/lang/String;
    const-string v2, "generic"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->FINGERPRINT:Ljava/lang/String;
    const-string v2, "vbox"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->FINGERPRINT:Ljava/lang/String;
    const-string v2, "test-keys"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->FINGERPRINT:Ljava/lang/String;
    const-string v2, "bluestacks"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0

    sget-object v1, Landroid/os/Build;->MODEL:Ljava/lang/String;
    const-string v2, "sdk"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->MODEL:Ljava/lang/String;
    const-string v2, "emulator"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->MODEL:Ljava/lang/String;
    const-string v2, "bluestacks"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->MODEL:Ljava/lang/String;
    const-string v2, "droid4x"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->MODEL:Ljava/lang/String;
    const-string v2, "memu"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0

    sget-object v1, Landroid/os/Build;->MANUFACTURER:Ljava/lang/String;
    const-string v2, "genymotion"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->MANUFACTURER:Ljava/lang/String;
    const-string v2, "unknown"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScoreExact(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0

    sget-object v1, Landroid/os/Build;->PRODUCT:Ljava/lang/String;
    const-string v2, "google_sdk"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->PRODUCT:Ljava/lang/String;
    const-string v2, "sdk"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScoreExact(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->PRODUCT:Ljava/lang/String;
    const-string v2, "vbox"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0

    sget-object v1, Landroid/os/Build;->BRAND:Ljava/lang/String;
    const-string v2, "generic"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScoreExact(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->DEVICE:Ljava/lang/String;
    const-string v2, "generic"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScoreExact(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0

    sget-object v1, Landroid/os/Build;->BOARD:Ljava/lang/String;
    const-string v2, "nox"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0
    sget-object v1, Landroid/os/Build;->BOARD:Ljava/lang/String;
    const-string v2, "goldfish"
    invoke-static {v1, v2, v0}, Lorg/spynote/EmulatorGuard;->addScore(Ljava/lang/String;Ljava/lang/String;I)I
    move-result v0

    const/4 v1, 0x4
    if-lt v0, v1, :real
    const/4 v0, 0x1
    return v0
    :real
    const/4 v0, 0x0
    return v0
.end method
